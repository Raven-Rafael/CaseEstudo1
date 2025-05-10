using AutoMapper;
using CaseEstudo1.Architecture.Interfaces;
using CaseEstudo1.Data;
using CaseEstudo1.Domain;
using CaseEstudo1.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseEstudo1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BordaController : ControllerBase
    {
        private readonly IBordaService _bordaService;

        public BordaController(IBordaService bordaService)
        {
            _bordaService = bordaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BordaDTO>>> Listar()
        {
            var bordas = await _bordaService.ListarAsync();
            return Ok(bordas);
        }

        [HttpPost]
        public async Task<ActionResult<BordaDTO>> Criar([FromBody] CreateBordaDTO dto)
        {
            var novaBorda = await _bordaService.CriarAsync(dto);
            return CreatedAtAction(nameof(Listar), new { id = novaBorda.Id }, novaBorda);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] UpdateBordaDTO dto)
        {
            var atualizado = await _bordaService.AtualizarAsync(id, dto);
            if (!atualizado) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var deletado = await _bordaService.DeletarAsync(id);
            if (!deletado) return NotFound();
            return NoContent();
        }
    }
}
