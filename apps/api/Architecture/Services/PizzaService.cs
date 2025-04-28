using System.Collections.Generic;
using System.Threading.Tasks;
using CaseEstudo1.Architecture.Interfaces;
using CaseEstudo1.Data;
using CaseEstudo1.Domain;
using CaseEstudo1.DTOs;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace CaseEstudo1.Architecture.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PizzaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PizzaResponseDTO>> GetAllAsync()
        {
            var pizzas = await _context.Pizzas.Include(p => p.Borda).ToListAsync();
            return _mapper.Map<IEnumerable<PizzaResponseDTO>>(pizzas);
        }

        public async Task<PizzaResponseDTO?> GetByIdAsync(int id)
        {
            var pizza = await _context.Pizzas.Include(p => p.Borda).FirstOrDefaultAsync(p => p.Id == id);
            return pizza == null ? null : _mapper.Map<PizzaResponseDTO>(pizza);
        }

        public async Task<PizzaResponseDTO> CreatePizzaAsync(CreatePizzaDTO dto)
        {
            var pizza = _mapper.Map<Pizza>(dto);

            _context.Pizzas.Add(pizza);
            await _context.SaveChangesAsync();

            return _mapper.Map<PizzaResponseDTO>(pizza);
        }

        public async Task<PizzaResponseDTO?> UpdatePizzaAsync(int id, UpdatePizzaDTO dto)
        {
            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza == null) return null;

            _mapper.Map(dto, pizza);
            await _context.SaveChangesAsync();

            return _mapper.Map<PizzaResponseDTO>(pizza);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza == null) return false;

            _context.Pizzas.Remove(pizza);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
