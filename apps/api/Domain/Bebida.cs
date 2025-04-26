using System.Collections.Generic;

namespace CaseEstudo1.Domain
{
    public class Bebida
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public bool Disponivel { get; set; } = true;

        public ICollection<PrecoBebida> Precos { get; set; } = new List<PrecoBebida>();
    }
}
