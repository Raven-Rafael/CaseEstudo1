namespace CaseEstudo1.Domain
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public string Tamanho { get; set; } = string.Empty;
        public bool Disponivel { get; set; } = true;

        public int? BordaId { get; set; }
        public Borda? Borda { get; set; }


        public string? NomeBebida { get; set; }
        public decimal? PrecoBebida { get; set; }
    }
}
