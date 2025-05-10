using System;

namespace CaseEstudo1.DTOs
{
    public class PedidoResponseDTO
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }

        public string NomePizza { get; set; } = string.Empty;
        public decimal PrecoPizza { get; set; }

        public string? NomeBebida { get; set; }
        public decimal? PrecoBebida { get; set; }

        public string? NomeBorda { get; set; }
        public decimal? PrecoBorda { get; set; }

        public decimal Total { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
