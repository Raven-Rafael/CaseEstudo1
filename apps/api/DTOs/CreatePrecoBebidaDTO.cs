using CaseEstudo1.Domain;

    namespace CaseEstudo1.DTOs
    {
        public class CreatePrecoBebidaDTO
        {
            public int BebidaId { get; set; }
            public TamanhoBebidaEnum Tamanho { get; set; }
            public decimal Preco { get; set; }
        }
    }
