using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CaseEstudo1.Attributes
{
    public class ValidCpfAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("O CPF é obrigatório.");

            var cpf = value.ToString()?.Replace(".", "").Replace("-", "");

            if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11 || !Regex.IsMatch(cpf, "^[0-9]{11}$"))
                return new ValidationResult("CPF inválido: formato incorreto.");

            // Descarta CPFs com todos os dígitos iguais (ex: 111.111.111-11)
            if (new string(cpf[0], 11) == cpf)
                return new ValidationResult("CPF inválido.");

            // Valida os dois dígitos verificadores
            int[] mult1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mult2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * mult1[i];

            int resto = soma % 11;
            int dig1 = resto < 2 ? 0 : 11 - resto;

            tempCpf += dig1;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * mult2[i];

            resto = soma % 11;
            int dig2 = resto < 2 ? 0 : 11 - resto;

            string cpfValidado = tempCpf + dig2;

            if (cpf != cpfValidado)
                return new ValidationResult("CPF inválido.");

            return ValidationResult.Success;
        }
    }
}
