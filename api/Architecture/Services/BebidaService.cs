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
    public class BebidaService : IBebidaService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BebidaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BebidaResponseDTO>> ListarAsync()
        {
            var bebidas = await _context.Bebidas
                .Include(b => b.Precos)
                .ToListAsync();
            return _mapper.Map<IEnumerable<BebidaResponseDTO>>(bebidas);
        }

        public async Task<BebidaResponseDTO?> BuscarPorIdAsync(int id)
        {
            var bebida = await _context.Bebidas
                .Include(b => b.Precos)
                .FirstOrDefaultAsync(b => b.Id == id);

            return bebida == null ? null : _mapper.Map<BebidaResponseDTO>(bebida);
        }

        public async Task<BebidaResponseDTO> CriarAsync(CreateBebidaDTO dto)
        {
            var bebida = _mapper.Map<Bebida>(dto);

            _context.Bebidas.Add(bebida);
            await _context.SaveChangesAsync();

            return _mapper.Map<BebidaResponseDTO>(bebida);
        }

        public async Task<bool> AtualizarAsync(int id, UpdateBebidaDTO dto)
        {
            var bebida = await _context.Bebidas
                .Include(b => b.Precos)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (bebida == null)
                return false;

            bebida.Nome = dto.Nome;
            bebida.Disponivel = dto.Disponivel;

            _context.PrecosBebidaPorTamanho.RemoveRange(bebida.Precos);

            bebida.Precos = dto.Precos.Select(p => new PrecoBebidaPorTamanho
            {
                Tamanho = p.Tamanho,
                Preco = p.Preco
            }).ToList();

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var bebida = await _context.Bebidas
                .Include(b => b.Precos)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (bebida == null)
                return false;

            _context.Bebidas.Remove(bebida);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
