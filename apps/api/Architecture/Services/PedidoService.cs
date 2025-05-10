using CaseEstudo1.Architecture.Interfaces;
using CaseEstudo1.Data;
using CaseEstudo1.Domain;
using CaseEstudo1.DTOs;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace CaseEstudo1.Architecture.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PedidoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PedidoResponseDTO> CriarPedidoAsync(PedidoDTO pedidoDto)
        {
            var pizza = await _context.Pizzas
                .Include(p => p.Borda)
                .FirstOrDefaultAsync(p => p.Id == pedidoDto.PizzaId);

            if (pizza == null) throw new Exception("Pizza não encontrada!");

            var precoBorda = pizza.Borda?.Preco ?? 0m;

            var pedido = new Pedido
            {
                PizzaId = pizza.Id,
                NomeCliente = pedidoDto.NomeCliente,
                TelefoneCliente = pedidoDto.TelefoneCliente,
                NomeBebida = pedidoDto.NomeBebida,
                PrecoBebida = pedidoDto.PrecoBebida,
                PrecoTotal = pizza.Preco + (pedidoDto.PrecoBebida ?? 0m),
                Status = "Em processamento"
            };

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return _mapper.Map<PedidoResponseDTO>(pedido);
        }

        public async Task<IEnumerable<PedidoResponseDTO>> ListarPedidosAsync()
        {
            var pedidos = await _context.Pedidos
                .Include(p => p.Pizza)
                .ThenInclude(p => p.Borda)
                .ToListAsync();

            return _mapper.Map<IEnumerable<PedidoResponseDTO>>(pedidos);
        }

        public async Task<PedidoResponseDTO?> BuscarPedidoPorIdAsync(int id)
        {
            var pedido = await _context.Pedidos
                .Include(p => p.Pizza)
                .ThenInclude(p => p.Borda)
                .FirstOrDefaultAsync(p => p.Id == id);

            return pedido == null ? null : _mapper.Map<PedidoResponseDTO>(pedido);
        }

        public async Task<bool> AtualizarStatusAsync(int id, string novoStatus)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null) return false;

            pedido.Status = novoStatus;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletarPedidoAsync(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null) return false;

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
