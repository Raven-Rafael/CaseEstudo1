using AutoMapper;
using CaseEstudo1.Data;
using CaseEstudo1.Domain;
using CaseEstudo1.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CaseEstudo1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UsuarioController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<UsuarioResponseDTO>> Registrar([FromBody] RegistroUsuarioDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                SenhaHash = HashSenha(dto.Senha)
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<UsuarioResponseDTO>(usuario);
            return CreatedAtAction(nameof(Registrar), new { id = usuario.Id }, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioResponseDTO>> GetById(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();

            var dto = new UsuarioResponseDTO
            {
                Nome = usuario.Nome,
                Email = usuario.Email
            };

            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RegistroUsuarioDTO dto)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();

            usuario.Nome = dto.Nome;
            usuario.SenhaHash = HashSenha(dto.Senha);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioResponseDTO>> Login([FromBody] LoginDTO dto)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (usuario == null || usuario.SenhaHash != HashSenha(dto.Senha))
                return Unauthorized("E-mail ou senha inválidos.");

            var response = _mapper.Map<UsuarioResponseDTO>(usuario);
            return Ok(response);
        }

        private string HashSenha(string senha)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(senha);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
