namespace CaseEstudo1.Domain
{ 
    public class PrecoBebida
    {
        public int Id { get; set; }
        public TamanhoBebidaEnum Tamanho { get; set; }
        public decimal Preco { get; set; }

        public int BebidaId { get; set; }
        public Bebida Bebida { get; set; } = null!;
    }
}