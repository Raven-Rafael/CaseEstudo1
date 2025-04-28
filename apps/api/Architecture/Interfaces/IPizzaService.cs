using CaseEstudo1.DTOs;
using CaseEstudo1.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseEstudo1.Architecture.Interfaces
{
    public interface IPizzaService
    {
        Task<IEnumerable<PizzaResponseDTO>> GetAllAsync();
        Task<PizzaResponseDTO?> GetByIdAsync(int id);
        Task<PizzaResponseDTO> CreatePizzaAsync(CreatePizzaDTO dto);
        Task<PizzaResponseDTO?> UpdatePizzaAsync(int id, UpdatePizzaDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
