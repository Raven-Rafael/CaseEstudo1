using System.Collections.Generic;
using System.Threading.Tasks;
using CaseEstudo1.Architecture.Interfaces;
using CaseEstudo1.Data;
using CaseEstudo1.Domain;
using CaseEstudo1.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CaseEstudo1.Architecture.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly AppDbContext _context;

        public PizzaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pizza>> GetAllAsync()
        {
            return await _context.Pizzas.ToListAsync();
        }

        public async Task<Pizza?> GetByIdAsync(int id)
        {
            return await _context.Pizzas.FindAsync(id);
        }

        public async Task<Pizza> CreateAsync(Pizza pizza)
        {
            await _context.Pizzas.AddAsync(pizza);
            await _context.SaveChangesAsync();
            return pizza;
        }

        public async Task<Pizza?> UpdateAsync(int id, Pizza pizza)
        {
            var existingPizza = await _context.Pizzas.FindAsync(id);
            if (existingPizza == null) return null;

            existingPizza.Nome = pizza.Nome;
            existingPizza.Descricao = pizza.Descricao;
            existingPizza.Preco = pizza.Preco;
            existingPizza.Tamanho = pizza.Tamanho;
            existingPizza.Disponivel = pizza.Disponivel;

            await _context.SaveChangesAsync();
            return existingPizza;
        }


        public async Task<Pizza> CreatePizzaAsync(CreatePizzaDTO dto)
        {
            var pizza = new Pizza
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Tamanho = dto.Tamanho,
                Disponivel = dto.Disponivel,
                Preco = dto.Preco
            };

            _context.Pizzas.Add(pizza);
            await _context.SaveChangesAsync();
            return pizza;
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
