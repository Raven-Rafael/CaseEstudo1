namespace CaseEstudo1.Domain
{
    public class Sabor
    {
        public int Id { get; set; }
        public string? Imagem { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Tipo { get; set; } = "Tradicional";


        public ICollection<PizzaSabor> PizzasSabores { get; set; } = new List<PizzaSabor>();
        public ICollection<SaborIngrediente> SaboresIngredientes { get; set; } = new List<SaborIngrediente>();
    }
}
