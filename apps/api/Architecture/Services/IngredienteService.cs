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
    public class IngredienteService : IIngredienteService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public IngredienteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IngredienteDTO>> ListarAsync()
        {
            var ingredientes = await _context.Ingredientes.ToListAsync();
            return _mapper.Map<IEnumerable<IngredienteDTO>>(ingredientes);
        }

        public async Task<IngredienteDTO?> BuscarPorIdAsync(int id)
        {
            var ingrediente = await _context.Ingredientes.FindAsync(id);
            return ingrediente == null ? null : _mapper.Map<IngredienteDTO>(ingrediente);
        }

        public async Task<IngredienteDTO> CriarAsync(CreateIngredienteDTO dto)
        {
            var ingrediente = _mapper.Map<Ingrediente>(dto);
            _context.Ingredientes.Add(ingrediente);
            await _context.SaveChangesAsync();
            return _mapper.Map<IngredienteDTO>(ingrediente);
        }

        public async Task<bool> AtualizarAsync(int id, UpdateIngredienteDTO dto)
        {
            var ingrediente = await _context.Ingredientes.FindAsync(id);
            if (ingrediente == null) return false;

            ingrediente.Nome = dto.Nome;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var ingrediente = await _context.Ingredientes.FindAsync(id);
            if (ingrediente == null) return false;

            _context.Ingredientes.Remove(ingrediente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
