namespace CaseEstudo1.Domain
{
    public class SaborIngrediente
    {
        public int SaborId { get; set; }
        public Sabor Sabor { get; set; } = null!;

        public int IngredienteId { get; set; }
        public Ingrediente Ingrediente { get; set; } = null!;
    }
}
