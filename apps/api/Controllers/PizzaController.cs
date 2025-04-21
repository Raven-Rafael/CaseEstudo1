using CaseEstudo1.Domain;
using CaseEstudo1.DTOs;
using CaseEstudo1.Architecture.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CaseEstudo1.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace CaseEstudo1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PizzaController(IPizzaService pizzaService, IMapper mapper, AppDbContext context)
        {
            _pizzaService = pizzaService;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaResponseDTO>>> GetAll()
        {
            var pizzas = await _pizzaService.GetAllAsync();
            var response = _mapper.Map<IEnumerable<PizzaResponseDTO>>(pizzas);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaResponseDTO>> GetById(int id)
        {
            var pizza = await _pizzaService.GetByIdAsync(id);
            if (pizza == null)
                return NotFound();

            var response = _mapper.Map<PizzaResponseDTO>(pizza);
            return Ok(response);
        }

        [HttpGet("{id}/detalhada")]
        public async Task<ActionResult<PizzaDetalhadaDTO>> GetDetalhada(int id)
        {
            var pizza = await _context.Pizzas
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pizza == null)
                return NotFound();

            
            var dto = new PizzaDetalhadaDTO
            {
                Id = pizza.Id,
                Nome = pizza.Nome,
                Descricao = pizza.Descricao,
                Preco = pizza.Preco,
                Tamanho = pizza.Tamanho,
                Disponivel = pizza.Disponivel,
                NomeBorda = null,
                Sabores = new(), 
                Ingredientes = new()
            };

            return Ok(dto);
        }


        [HttpPost]
        public async Task<ActionResult<PizzaResponseDTO>> Create([FromBody] CreatePizzaDTO dto)
        {
            var pizza = _mapper.Map<Pizza>(dto);
            var created = await _pizzaService.CreateAsync(pizza);
            var response = _mapper.Map<PizzaResponseDTO>(created);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PizzaResponseDTO>> Update(int id, [FromBody] UpdatePizzaDTO dto)
        {
            var pizza = _mapper.Map<Pizza>(dto);
            var updated = await _pizzaService.UpdateAsync(id, pizza);

            if (updated == null)
                return NotFound();

            var response = _mapper.Map<PizzaResponseDTO>(updated);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _pizzaService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
