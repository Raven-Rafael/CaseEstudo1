using CaseEstudo1.Domain;

namespace CaseEstudo1.DTOs
    {
        public class PrecoBebidaDTO
        {
            public int Id { get; set; }
            public TamanhoBebidaEnum Tamanho { get; set; }
            public decimal Preco { get; set; }
        }
    }
