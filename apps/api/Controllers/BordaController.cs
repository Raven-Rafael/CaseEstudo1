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
    public class BordaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BordaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BordaPrecoDTO>>> GetByTamanho([FromQuery] TamanhoPizzaEnum tamanho)
        {
            var bordas = await _context.BordasPrecosPorTamanhos
                .Where(b => b.Tamanho == tamanho)
                .Include(b => b.Borda)
                .Select(b => new BordaPrecoDTO
                {
                    Nome = b.Borda!.Nome,
                    Preco = b.Preco
                })
                .ToListAsync();

            if (!bordas.Any())
                return NotFound($"Nenhuma borda encontrada para o tamanho: {tamanho}");

            return Ok(bordas);
        }
    }
    
}
