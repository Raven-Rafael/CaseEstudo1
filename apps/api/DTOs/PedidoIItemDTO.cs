using CaseEstudo1.Domain;

namespace CaseEstudo1.DTOs
{
    public class PedidoItemDTO
    {
        public int? PizzaId { get; set; }
        public int? BebidaId { get; set; }
        public TamanhoBebidaEnum? TamanhoBebida { get; set; }
        public int Quantidade { get; set; }
    }
}
