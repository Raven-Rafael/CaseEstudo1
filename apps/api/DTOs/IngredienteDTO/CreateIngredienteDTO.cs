using System.ComponentModel.DataAnnotations;

namespace CaseEstudo1.DTOs
{
    public class CreateIngredienteDTO
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;
    }
}
