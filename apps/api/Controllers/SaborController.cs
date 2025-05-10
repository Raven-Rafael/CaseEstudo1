using AutoMapper;
using CaseEstudo1.Data;
using CaseEstudo1.DTOs;
using CaseEstudo1.Domain;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CaseEstudo1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaborController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SaborController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaborDTO>>> Get()
        {
            var sabores = await _context.Sabores.ToListAsync();
            return _mapper.Map<List<SaborDTO>>(sabores);
        }

        [HttpPost]
        public async Task<ActionResult<Sabor>> CreateSabor(Sabor sabor)
        {
            if (string.IsNullOrWhiteSpace(sabor.Nome))
                return BadRequest("O nome do sabor é obrigatório.");

            _context.Sabores.Add(sabor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = sabor.Id }, sabor);
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
