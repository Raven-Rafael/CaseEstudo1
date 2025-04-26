using System.Collections.Generic;

namespace CaseEstudo1.DTOs
{
    public class BebidaComPrecosDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public bool Disponivel { get; set; }
        public List<PrecoBebidaDTO> Precos { get; set; } = new();
    }
}
