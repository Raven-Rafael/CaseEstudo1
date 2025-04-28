using System;
using System.ComponentModel.DataAnnotations;

namespace CaseEstudo1.Domain
{
    public class Pedido
    {
        public int Id { get; set; }

        public DateTime DataPedido { get; set; } = DateTime.Now;

        public string NomeCliente { get; set; } = string.Empty;

        public string? TelefoneCliente { get; set; }

        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; } = null!;

        public string? NomeBebida { get; set; }

        public decimal? PrecoBebida { get; set; }

        public decimal PrecoTotal { get; set; }

        public string Status { get; set; } = "Em processamento";
    }
}
