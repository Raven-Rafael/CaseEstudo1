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
    public class BebidaController : ControllerBase
    {
        private readonly IBebidaService _bebidaService;

        public BebidaController(IBebidaService bebidaService)
        {
            _bebidaService = bebidaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BebidaComPrecosDTO>>> GetAll()
        {
            var bebidas = await _bebidaService.GetAllAsync();
            return Ok(bebidas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BebidaComPrecosDTO>> GetById(int id)
        {
            var bebida = await _bebidaService.GetByIdAsync(id);
            if (bebida == null) return NotFound();
            return Ok(bebida);
        }

        [HttpGet("disponiveis")]
        public async Task<ActionResult<IEnumerable<BebidaComPrecosDTO>>> GetDisponiveis()
        {
            var bebidas = await _bebidaService.GetDisponiveisAsync();
            return Ok(bebidas);
        }

        [HttpGet("tipo/{tipo}")]
        public async Task<ActionResult<IEnumerable<BebidaComPrecosDTO>>> GetByTipo(string tipo)
        {
            var bebidas = await _bebidaService.GetByTipoAsync(tipo);
            return Ok(bebidas);
        }

        [HttpPost]
        public async Task<ActionResult<BebidaDTO>> Create(CreateBebidaDTO dto)
        {
            var bebida = await _bebidaService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = bebida.Id }, bebida);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBebidaDTO dto)
        {
            var sucesso = await _bebidaService.UpdateAsync(id, dto);
            if (!sucesso) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sucesso = await _bebidaService.DeleteAsync(id);
            if (!sucesso) return NotFound();
            return NoContent();
        }

        [HttpPost("preco")]
        public async Task<ActionResult<PrecoBebidaDTO>> AddPreco(CreatePrecoBebidaDTO dto)
        {
            var preco = await _bebidaService.AddPrecoAsync(dto);
            return Ok(preco);
        }

        [HttpDelete("preco/{id}")]
        public async Task<IActionResult> DeletePreco(int id)
        {
            var sucesso = await _bebidaService.DeletePrecoAsync(id);
            if (!sucesso) return NotFound();
            return NoContent();
        }
    }
}
