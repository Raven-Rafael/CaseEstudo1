namespace CaseEstudo1.Domain
{
    public class SaborPrecoPorTamanho
    {
        public int Id { get; set; }
        public TamanhoPizzaEnum Tamanho { get; set; }

        public int SaborId { get; set; }
        public Sabor? Sabor { get; set; }

        public decimal Preco { get; set; }
    }
}
