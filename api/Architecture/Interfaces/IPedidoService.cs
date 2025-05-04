using CaseEstudo1.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseEstudo1.Architecture.Interfaces
{
    public interface IPedidoService
    {
        Task<PedidoResponseDTO> CriarPedidoAsync(PedidoDTO pedidoDto);
        Task<IEnumerable<PedidoResponseDTO>> ListarPedidosAsync();
        Task<PedidoResponseDTO?> BuscarPedidoPorIdAsync(int id);
        Task<bool> AtualizarStatusAsync(int id, string novoStatus);
        Task<bool> DeletarPedidoAsync(int id);

    }
}
