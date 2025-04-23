namespace CaseEstudo1.DTOs
{
    public class PizzaResponseDTO
    {
        public int Id { get; set; }
        public decimal Preco { get; set; }
        public string? Imagem { get; set; }
        public bool Disponivel { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Tamanho { get; set; } = string.Empty;

    }
}
