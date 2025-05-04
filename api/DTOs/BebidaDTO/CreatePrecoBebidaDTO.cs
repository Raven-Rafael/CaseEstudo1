using System.ComponentModel.DataAnnotations;
using CaseEstudo1.Domain;

namespace CaseEstudo1.DTOs
{
    public class CreatePrecoBebidaDTO
    {
        [Required]
        public TamanhoBebidaEnum Tamanho { get; set; }

        [Required]
        [Range(0.01, 999.99)]
        public decimal Preco { get; set; }
    }
}
