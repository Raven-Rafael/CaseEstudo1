using CaseEstudo1.Data;
using CaseEstudo1.DTOs;
using CaseEstudo1.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseEstudo1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public IngredienteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredienteDTO>>> GetAll()
        {
            var ingredientes = await _context.Ingredientes
                .Select(i => new IngredienteDTO
                {
                    Id = i.Id,
                    Nome = i.Nome
                })
                .ToListAsync();

            return Ok(ingredientes);
        }

        [HttpPost]
        public async Task<ActionResult<Ingrediente>> Create(Ingrediente ingrediente)
        {
            _context.Ingredientes.Add(ingrediente);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = ingrediente.Id }, ingrediente);
        }
    }
}
