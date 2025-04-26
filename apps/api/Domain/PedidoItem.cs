namespace CaseEstudo1.Domain
{
    public class PedidoItem
    {
        public int Id { get; set; }

        public int? PizzaId { get; set; }
        public Pizza? Pizza { get; set; }

        public int? BebidaId { get; set; }
        public Bebida? Bebida { get; set; }

        public TamanhoBebidaEnum? TamanhoBebida { get; set; }

        public int Quantidade { get; set; }

        public decimal PrecoUnitario { get; set; }

        public decimal PrecoTotal => PrecoUnitario * Quantidade;
    }
}
