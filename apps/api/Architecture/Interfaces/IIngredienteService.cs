using CaseEstudo1.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CaseEstudo1.Architecture.Interfaces
{
    public interface IIngredienteService
    {
        Task<IEnumerable<IngredienteDTO>> ListarAsync();
        Task<IngredienteDTO?> BuscarPorIdAsync(int id);
        Task<IngredienteDTO> CriarAsync(CreateIngredienteDTO dto);
        Task<bool> AtualizarAsync(int id, UpdateIngredienteDTO dto);
        Task<bool> DeletarAsync(int id);
    }
}
