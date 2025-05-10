using System.ComponentModel.DataAnnotations;
using CaseEstudo1.Data;
using Microsoft.Extensions.DependencyInjection;

namespace CaseEstudo1.Attributes
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not string email)
                return new ValidationResult("E-mail inválido.");

            // Acessa o AppDbContext a partir do serviço DI
            var dbContext = validationContext.GetService(typeof(AppDbContext)) as AppDbContext;
            if (dbContext == null)
                return new ValidationResult("Erro interno ao acessar o banco de dados.");

            var emailJaExiste = dbContext.Usuarios.Any(u => u.Email == email);
            if (emailJaExiste)
                return new ValidationResult(ErrorMessage ?? "Este e-mail já está cadastrado.");

            return ValidationResult.Success;
        }
    }
}