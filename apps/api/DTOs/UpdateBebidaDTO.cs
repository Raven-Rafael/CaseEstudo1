using CaseEstudo1.Domain;

    namespace CaseEstudo1.DTOs
    {
        public class UpdateBebidaDTO
        {
            public string Nome { get; set; } = string.Empty;
            public bool Disponivel { get; set; } = true;
        }
    }
