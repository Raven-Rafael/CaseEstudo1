using CaseEstudo1.Architecture.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CaseEstudo1.DTOs;
using CaseEstudo1.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseEstudo1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaResponseDTO>>> Listar()
        {
            var pizzas = await _pizzaService.GetAllAsync();
            return Ok(pizzas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaResponseDTO>> BuscarPorId(int id)
        {
            var pizza = await _pizzaService.GetByIdAsync(id);
            if (pizza == null)
                return NotFound();

            return Ok(pizza);
        }

        [HttpPost]
        public async Task<ActionResult<PizzaResponseDTO>> Criar([FromBody] CreatePizzaDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var novaPizza = await _pizzaService.CreatePizzaAsync(dto);
            return CreatedAtAction(nameof(BuscarPorId), new { id = novaPizza.Id }, novaPizza);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] UpdatePizzaDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var atualizado = await _pizzaService.UpdatePizzaAsync(id, dto);
            if (atualizado == null) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var deletado = await _pizzaService.DeleteAsync(id);
            if (!deletado) return NotFound();

            return NoContent();
        }
    }
}
