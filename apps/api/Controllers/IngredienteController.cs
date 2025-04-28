using AutoMapper;
using CaseEstudo1.Data;
using CaseEstudo1.DTOs;
using CaseEstudo1.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CaseEstudo1.Architecture.Interfaces;

namespace CaseEstudo1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredienteController : ControllerBase
    {
        private readonly IIngredienteService _ingredienteService;

        public IngredienteController(IIngredienteService ingredienteService)
        {
            _ingredienteService = ingredienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredienteDTO>>> Listar()
        {
            var ingredientes = await _ingredienteService.ListarAsync();
            return Ok(ingredientes);
        }

        [HttpPost]
        public async Task<ActionResult<IngredienteDTO>> Criar([FromBody] CreateIngredienteDTO dto)
        {
            var novoIngrediente = await _ingredienteService.CriarAsync(dto);
            return CreatedAtAction(nameof(Listar), new { id = novoIngrediente.Id }, novoIngrediente);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] UpdateIngredienteDTO dto)
        {
            var atualizado = await _ingredienteService.AtualizarAsync(id, dto);
            if (!atualizado) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var deletado = await _ingredienteService.DeletarAsync(id);
            if (!deletado) return NotFound();
            return NoContent();
        }
    }
}
