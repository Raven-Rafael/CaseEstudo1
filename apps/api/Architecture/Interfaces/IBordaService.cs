using CaseEstudo1.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseEstudo1.Architecture.Interfaces
{
    public interface IBordaService
    {
        Task<IEnumerable<BordaDTO>> ListarAsync();
        Task<BordaDTO?> BuscarPorIdAsync(int id);
        Task<BordaDTO> CriarAsync(CreateBordaDTO dto);
        Task<bool> AtualizarAsync(int id, UpdateBordaDTO dto);
        Task<bool> DeletarAsync(int id);
    }
}
