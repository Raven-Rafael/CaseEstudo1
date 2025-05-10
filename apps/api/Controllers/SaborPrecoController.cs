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
    public class SaborPrecoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SaborPrecoController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaborPrecoPorTamanho>>> GetByTamanho([FromQuery] TamanhoPizzaEnum tamanho)
        {
            var precos = await _context.SaboresPrecosPorTamanhos
                .Where(s => s.Tamanho == tamanho)
                .Include(s => s.Sabor)
                .ToListAsync();

            if (!precos.Any())
                return NotFound($"Nenhum sabor com preço encontrado para o tamanho: {tamanho}");

            return Ok(precos);
        }


        [HttpPost]
        public async Task<ActionResult<SaborPrecoPorTamanho>> Create(SaborPrecoPorTamanho preco)
        {
            var saborExiste = await _context.Sabores.AnyAsync(s => s.Id == preco.SaborId);
            if (!saborExiste)
                return BadRequest("SaborId inválido.");

            _context.SaboresPrecosPorTamanhos.Add(preco);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByTamanho), new { tamanho = preco.Tamanho }, preco);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SaborPrecoPorTamanho preco)
        {
            if (id != preco.Id)
                return BadRequest("ID da URL não confere com o objeto enviado.");

            _context.Entry(preco).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var preco = await _context.SaboresPrecosPorTamanhos.FindAsync(id);
            if (preco == null) return NotFound();

            _context.SaboresPrecosPorTamanhos.Remove(preco);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
