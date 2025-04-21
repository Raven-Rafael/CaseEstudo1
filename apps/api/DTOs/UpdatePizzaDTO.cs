namespace CaseEstudo1.DTOs
{
    public class UpdatePizzaDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public string Tamanho { get; set; } = string.Empty;
        public bool Disponivel { get; set; } = true;
    }
}
