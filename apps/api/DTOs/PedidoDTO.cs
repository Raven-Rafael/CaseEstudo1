using System.Collections.Generic;

namespace CaseEstudo1.DTOs
{
    public class PedidoDTO
    {
        public List<PizzaPedidoDTO> Pizzas { get; set; } = new();
        public List<BebidaPedidoDTO> Bebidas { get; set; } = new();
    }

    public class PizzaPedidoDTO
    {
        public int PizzaId { get; set; }
        public List<int> SaboresIds { get; set; } = new();
        public int? BordaId { get; set; }
    }

    public class BebidaPedidoDTO
    {
        public int BebidaId { get; set; }
        public string Tamanho { get; set; } = string.Empty;
    }
}
