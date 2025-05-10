using System.Collections.Generic;

namespace CaseEstudo1.Domain
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public ICollection<SaborIngrediente> SaboresIngredientes { get; set; } = new List<SaborIngrediente>();
    }
}
