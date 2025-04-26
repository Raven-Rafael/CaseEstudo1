using CaseEstudo1.Domain;
using CaseEstudo1.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseEstudo1.Architecture.Interfaces
{
    public interface IBebidaService
    {
        // Bebida
        Task<IEnumerable<BebidaComPrecosDTO>> GetAllAsync();
        Task<BebidaComPrecosDTO?> GetByIdAsync(int id);
        Task<BebidaDTO> CreateAsync(CreateBebidaDTO dto);
        Task<bool> UpdateAsync(int id, UpdateBebidaDTO dto);
        Task<bool> DeleteAsync(int id);

        // Preço por Tamanho
        Task<PrecoBebidaDTO> AddPrecoAsync(CreatePrecoBebidaDTO dto);
        Task<bool> DeletePrecoAsync(int id);

        // Extras
        Task<IEnumerable<BebidaComPrecosDTO>> GetByTipoAsync(string tipo);
        Task<IEnumerable<BebidaComPrecosDTO>> GetDisponiveisAsync();
    }
}
