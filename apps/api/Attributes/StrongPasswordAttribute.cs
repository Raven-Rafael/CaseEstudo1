using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CaseEstudo1.Attributes
{
    public class StrongPasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var senha = value as string;

            if (string.IsNullOrWhiteSpace(senha))
                return new ValidationResult("A senha é obrigatória.");

            if (senha.Length < 8)
                return new ValidationResult("A senha deve ter no mínimo 8 caracteres.");

            if (!Regex.IsMatch(senha, "[a-z]"))
                return new ValidationResult("A senha deve conter pelo menos uma letra minúscula.");

            if (!Regex.IsMatch(senha, "[A-Z]"))
                return new ValidationResult("A senha deve conter pelo menos uma letra maiúscula.");

            if (!Regex.IsMatch(senha, "[0-9]"))
                return new ValidationResult("A senha deve conter pelo menos um número.");

            if (!Regex.IsMatch(senha, "[!@#$%^&*(),.?\":{}|<>]"))
                return new ValidationResult("A senha deve conter pelo menos um caractere especial.");

            return ValidationResult.Success;
        }
    }
}
