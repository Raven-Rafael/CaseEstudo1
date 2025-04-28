using AutoMapper;
using CaseEstudo1.Architecture.Interfaces;
using CaseEstudo1.Data;
using CaseEstudo1.Domain;
using CaseEstudo1.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseEstudo1.Architecture.Services
{
    public class BordaService : IBordaService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BordaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BordaDTO>> ListarAsync()
        {
            var bordas = await _context.Bordas.ToListAsync();
            return _mapper.Map<IEnumerable<BordaDTO>>(bordas);
        }

        public async Task<BordaDTO?> BuscarPorIdAsync(int id)
        {
            var borda = await _context.Bordas.FindAsync(id);
            return borda == null ? null : _mapper.Map<BordaDTO>(borda);
        }

        public async Task<BordaDTO> CriarAsync(CreateBordaDTO dto)
        {
            var borda = _mapper.Map<Borda>(dto);
            _context.Bordas.Add(borda);
            await _context.SaveChangesAsync();
            return _mapper.Map<BordaDTO>(borda);
        }

        public async Task<bool> AtualizarAsync(int id, UpdateBordaDTO dto)
        {
            var borda = await _context.Bordas.FindAsync(id);
            if (borda == null) return false;

            borda.Nome = dto.Nome;
            borda.Preco = dto.Preco;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var borda = await _context.Bordas.FindAsync(id);
            if (borda == null) return false;

            _context.Bordas.Remove(borda);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
