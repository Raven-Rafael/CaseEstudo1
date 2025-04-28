namespace CaseEstudo1.Domain
{
    public class PizzaSabor
    {
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; } = null!;

        public int SaborId { get; set; }
        public Sabor Sabor { get; set; } = null!;
    }
}
