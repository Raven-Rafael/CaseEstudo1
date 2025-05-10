namespace CaseEstudo1.DTOs
{
    public class PizzaResponseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public string Tamanho { get; set; } = string.Empty;
        public bool Disponivel { get; set; }
        public string? NomeBebida { get; set; }
        public decimal? PrecoBebida { get; set; }
        public string? NomeBorda { get; set; }
    }
}
