using AutoMapper;
using CaseEstudo1.Architecture.Interfaces;
using CaseEstudo1.Data;
using CaseEstudo1.Domain;
using CaseEstudo1.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var pedido = _mapper.Map<Pedido>(pedidoDto);

            decimal total = 0m;

            foreach (var pizzaItem in pedidoDto.Pizzas)
            {
                var pizza = await _context.Pizzas
                    .Include(p => p.Borda)
                    .Include(p => p.PizzasSabores)
                        .ThenInclude(ps => ps.Sabor)
                    .FirstOrDefaultAsync(p => p.Id == pizzaItem.PizzaId);

                if (pizza != null)
                {
                    total += pizza.Preco;
                }
            }

            foreach (var bebidaItem in pedidoDto.Bebidas)
            {
                var preco = await _context.PrecosBebidas
                    .Where(pb => pb.BebidaId == bebidaItem.BebidaId && pb.Tamanho.ToString() == bebidaItem.Tamanho)
                    .Select(pb => pb.Preco)
                    .FirstOrDefaultAsync();

                total += preco;
            }

            pedido.Total = total;
            pedido.Status = "Em processamento."; 

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return _mapper.Map<PedidoResponseDTO>(pedido);
        }

        public async Task<IEnumerable<PedidoResponseDTO>> ListarPedidosAsync()
        {
            var pedidos = await _context.Pedidos
                .Include(p => p.ItensPizza)
                    .ThenInclude(ip => ip.Pizza)
                .Include(p => p.ItensBebida)
                    .ThenInclude(ib => ib.Bebida)
                .ToListAsync();

            return _mapper.Map<IEnumerable<PedidoResponseDTO>>(pedidos);
        }

        public async Task<PedidoResponseDTO?> BuscarPedidoPorIdAsync(int id)
        {
            var pedido = await _context.Pedidos
                .Include(p => p.ItensPizza)
                    .ThenInclude(ip => ip.Pizza)
                .Include(p => p.ItensBebida)
                    .ThenInclude(ib => ib.Bebida)
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
