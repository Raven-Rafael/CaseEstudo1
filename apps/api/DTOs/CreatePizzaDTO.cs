using System.ComponentModel.DataAnnotations;

namespace CaseEstudo1.DTOs
{
    public class CreatePizzaDTO
    {
        [Required(ErrorMessage = "O nome da pizza é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Descricao { get; set; } = string.Empty;

        [Range(0.01, 999.99, ErrorMessage = "O preço deve estar entre 0.01 e 999.99.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O tamanho é obrigatório.")]
        public string Tamanho { get; set; } = string.Empty;

        public bool Disponivel { get; set; } = true;
    }
}
