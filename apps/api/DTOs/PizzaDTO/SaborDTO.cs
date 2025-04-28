namespace CaseEstudo1.DTOs
{
    public class SaborDTO
    {
        public decimal Preco { get; set; }
        public string? Imagem { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Tipo { get; set; } = "Tradicional";
        
    }
}
