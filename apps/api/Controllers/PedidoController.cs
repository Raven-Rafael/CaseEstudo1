using AutoMapper;
using CaseEstudo1.Architecture.Interfaces;
using CaseEstudo1.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseEstudo1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public async Task<ActionResult<PedidoResponseDTO>> CriarPedido([FromBody] PedidoDTO pedidoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var novoPedido = await _pedidoService.CriarPedidoAsync(pedidoDto);
            return CreatedAtAction(nameof(BuscarPorId), new { id = novoPedido.Id }, novoPedido);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoResponseDTO>>> ListarPedidos()
        {
            var pedidos = await _pedidoService.ListarPedidosAsync();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoResponseDTO>> BuscarPorId(int id)
        {
            var pedido = await _pedidoService.BuscarPedidoPorIdAsync(id);
            if (pedido == null)
                return NotFound();

            return Ok(pedido);


        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> AtualizarStatus(int id, [FromBody] string novoStatus)
        {
            var sucesso = await _pedidoService.AtualizarStatusAsync(id, novoStatus);
            if (!sucesso) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarPedido(int id)
        {
            var sucesso = await _pedidoService.DeletarPedidoAsync(id);
            if (!sucesso) return NotFound();

            return NoContent();
        }
    }


}
