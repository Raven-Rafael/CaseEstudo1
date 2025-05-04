namespace CaseEstudo1.Domain;

    public class BordaPrecoPorTamanho
    {
        public int Id { get; set; }
        public TamanhoPizzaEnum Tamanho { get; set; }
        public int BordaId { get; set; }
        public Borda? Borda { get; set; }
        public decimal Preco { get; set; }
    }
    public enum TamanhoPizzaEnum
    {
        Broto,
        Media,
        Grande,
        Big,
        Gigante
    }


