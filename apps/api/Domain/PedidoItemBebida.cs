namespace CaseEstudo1.Domain
{
    public class PedidoItemBebida
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; } = null!;

        public int BebidaId { get; set; }
        public Bebida Bebida { get; set; } = null!;

        public string Tamanho { get; set; } = string.Empty;
    }
}
