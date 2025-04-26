using System.Collections.Generic;

namespace CaseEstudo1.Domain
{
    public class Pedido
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; } = "Em andamento";

        public ICollection<PedidoItemPizza> ItensPizza { get; set; } = new List<PedidoItemPizza>();
        public ICollection<PedidoItemBebida> ItensBebida { get; set; } = new List<PedidoItemBebida>();
    }
}
