namespace CaseEstudo1.Domain;
using System.ComponentModel.DataAnnotations;
using CaseEstudo1.Attributes; 

public class Usuario
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MaxLength(100)]
    [MinLength(3)]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "O e-mail deve ser válido.")]
    [UniqueEmail(ErrorMessage = "Este e-mail já está cadastrado.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "A senha é obrigatória.")]
    [StrongPassword(ErrorMessage = "A senha deve conter no mínimo 8 caracteres, uma letra maiúscula, uma letra minúscula, um número e um caractere especial.")]
    public string SenhaHash { get; set; } = string.Empty;


}
