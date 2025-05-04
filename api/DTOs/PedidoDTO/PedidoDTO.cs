namespace CaseEstudo1.DTOs
{
    public class PedidoDTO
    {
        public string NomeCliente { get; set; } = string.Empty;

        public string? TelefoneCliente { get; set; }

        public int PizzaId { get; set; }

        public string? NomeBebida { get; set; }

        public decimal? PrecoBebida { get; set; }
    }
}
