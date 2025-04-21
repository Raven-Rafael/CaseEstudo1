using System.Collections.Generic;
using System.Threading.Tasks;
using CaseEstudo1.Data;
using CaseEstudo1.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaseEstudo1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaborController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SaborController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sabor>>> GetSabores()
        {
            var sabores = await _context.Sabores.ToListAsync();
            return Ok(sabores);
        }

        [HttpPost]
        public async Task<ActionResult<Sabor>> CreateSabor(Sabor sabor)
        {
            if (string.IsNullOrWhiteSpace(sabor.Nome))
                return BadRequest("O nome do sabor é obrigatório.");

            _context.Sabores.Add(sabor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSabores), new { id = sabor.Id }, sabor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSabor(int id, Sabor sabor)
        {
            if (id != sabor.Id)
                return BadRequest("ID da URL não confere com o objeto enviado.");

            var saborExistente = await _context.Sabores.FindAsync(id);
            if (saborExistente == null) return NotFound();

            saborExistente.Nome = sabor.Nome;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSabor(int id)
        {
            var sabor = await _context.Sabores.FindAsync(id);
            if (sabor == null) return NotFound();

            _context.Sabores.Remove(sabor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
