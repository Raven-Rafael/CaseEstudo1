using System;
using System.Collections.Generic;

namespace CaseEstudo1.DTOs
{
    public class PedidoResponseDTO
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public List<PedidoItemResponseDTO> Itens { get; set; } = new();
        public decimal ValorTotal { get; set; }
    }
}
