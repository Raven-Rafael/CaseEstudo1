using System.ComponentModel.DataAnnotations;

namespace CaseEstudo1.DTOs
{
    public class CreateBordaDTO
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [Range(0.01, 999.99)]
        public decimal Preco { get; set; }
    }
}
