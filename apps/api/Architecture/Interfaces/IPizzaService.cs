using System.Collections.Generic;
using System.Threading.Tasks;
using CaseEstudo1.Domain;
using CaseEstudo1.DTOs;


namespace CaseEstudo1.Architecture.Interfaces
{
    public interface IPizzaService
    {
        Task<IEnumerable<Pizza>> GetAllAsync();
        Task<Pizza?> GetByIdAsync(int id);
        Task<Pizza> CreateAsync(Pizza pizza);
        Task<Pizza?> UpdateAsync(int id, Pizza pizza);
        Task<bool> DeleteAsync(int id);
        Task<Pizza> CreatePizzaAsync(CreatePizzaDTO dto);
    }
}
