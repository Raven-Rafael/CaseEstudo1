using CaseEstudo1.Domain;

namespace CaseEstudo1.DTOs
{
    public class PedidoItemResponseDTO
    {
        public int Id { get; set; }
        public string? NomePizza { get; set; }
        public string? NomeBebida { get; set; }
        public TamanhoBebidaEnum? TamanhoBebida { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal PrecoTotal { get; set; }
    }
}
