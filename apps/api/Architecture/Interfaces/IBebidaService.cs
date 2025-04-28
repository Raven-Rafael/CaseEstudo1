using CaseEstudo1.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseEstudo1.Architecture.Interfaces
{
    public interface IBebidaService
    {
        Task<IEnumerable<BebidaResponseDTO>> ListarAsync();
        Task<BebidaResponseDTO?> BuscarPorIdAsync(int id);
        Task<BebidaResponseDTO> CriarAsync(CreateBebidaDTO dto);
        Task<bool> AtualizarAsync(int id, UpdateBebidaDTO dto);
        Task<bool> DeletarAsync(int id);
    }
}
