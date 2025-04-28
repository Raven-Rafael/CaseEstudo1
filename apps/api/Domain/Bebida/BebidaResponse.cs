using System.Collections.Generic;

namespace CaseEstudo1.DTOs
{
    public class BebidaResponseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public bool Disponivel { get; set; } = true;
        public List<PrecoBebidaDTO> Precos { get; set; } = new();
    }
}
