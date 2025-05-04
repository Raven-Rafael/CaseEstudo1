using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaseEstudo1.DTOs
{
    public class CreateBebidaDTO
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string Tipo { get; set; } = string.Empty;

        [Required]
        public bool Disponivel { get; set; } = true;

        public string? ImagemUrl { get; set; }

        public List<CreatePrecoBebidaDTO> Precos { get; set; } = new();
    }
}
