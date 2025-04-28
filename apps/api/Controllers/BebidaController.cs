using CaseEstudo1.Architecture.Interfaces;
using CaseEstudo1.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseEstudo1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BebidaController : ControllerBase
    {
        private readonly IBebidaService _bebidaService;

        public BebidaController(IBebidaService bebidaService)
        {
            _bebidaService = bebidaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BebidaResponseDTO>>> Listar()
        {
            var bebidas = await _bebidaService.ListarAsync();
            return Ok(bebidas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BebidaResponseDTO>> BuscarPorId(int id)
        {
            var bebida = await _bebidaService.BuscarPorIdAsync(id);
            if (bebida == null)
                return NotFound();

            return Ok(bebida);
        }

        [HttpPost]
        public async Task<ActionResult<BebidaResponseDTO>> Criar([FromBody] CreateBebidaDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var novaBebida = await _bebidaService.CriarAsync(dto);
            return CreatedAtAction(nameof(BuscarPorId), new { id = novaBebida.Id }, novaBebida);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] UpdateBebidaDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var atualizado = await _bebidaService.AtualizarAsync(id, dto);
            if (!atualizado) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var deletado = await _bebidaService.DeletarAsync(id);
            if (!deletado) return NotFound();

            return NoContent();
        }
    }
}
