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

        public async Task<IEnumerable<BebidaComPrecosDTO>> GetAllAsync()
        {
            var bebidas = await _context.Bebidas
                .Include(b => b.Precos)
                .ToListAsync();

            return _mapper.Map<IEnumerable<BebidaComPrecosDTO>>(bebidas);
        }

        public async Task<BebidaComPrecosDTO?> GetByIdAsync(int id)
        {
            var bebida = await _context.Bebidas
                .Include(b => b.Precos)
                .FirstOrDefaultAsync(b => b.Id == id);

            return bebida == null ? null : _mapper.Map<BebidaComPrecosDTO>(bebida);
        }

        public async Task<BebidaDTO> CreateAsync(CreateBebidaDTO dto)
        {
            var bebida = _mapper.Map<Bebida>(dto);
            _context.Bebidas.Add(bebida);
            await _context.SaveChangesAsync();
            return _mapper.Map<BebidaDTO>(bebida);
        }

        public async Task<bool> UpdateAsync(int id, UpdateBebidaDTO dto)
        {
            var bebida = await _context.Bebidas.FindAsync(id);
            if (bebida == null) return false;

            _mapper.Map(dto, bebida);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var bebida = await _context.Bebidas.FindAsync(id);
            if (bebida == null) return false;

            _context.Bebidas.Remove(bebida);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PrecoBebidaDTO> AddPrecoAsync(CreatePrecoBebidaDTO dto)
        {
            var preco = _mapper.Map<PrecoBebida>(dto);
            _context.PrecosBebidas.Add(preco);
            await _context.SaveChangesAsync();
            return _mapper.Map<PrecoBebidaDTO>(preco);
        }

        public async Task<bool> DeletePrecoAsync(int id)
        {
            var preco = await _context.PrecosBebidas.FindAsync(id);
            if (preco == null) return false;

            _context.PrecosBebidas.Remove(preco);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<BebidaComPrecosDTO>> GetByTipoAsync(string tipo)
        {
            var bebidas = await _context.Bebidas
                .Include(b => b.Precos)
                .Where(b => b.Tipo == tipo)
                .ToListAsync();

            return _mapper.Map<IEnumerable<BebidaComPrecosDTO>>(bebidas);
        }

        public async Task<IEnumerable<BebidaComPrecosDTO>> GetDisponiveisAsync()
        {
            var bebidas = await _context.Bebidas
                .Include(b => b.Precos)
                .Where(b => b.Disponivel)
                .ToListAsync();

            return _mapper.Map<IEnumerable<BebidaComPrecosDTO>>(bebidas);
        }
    }
}
