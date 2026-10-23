namespace ProjetoAcademia.Models
{
    public class Pagamento : Pagamentos
    {
        public Pagamento() : base() { }
        public Pagamento(int pagamentoid) : base(pagamentoid) { }
        public Pagamento(int alunoid, decimal valor, string dataPagamento, string mesReferencia) : base(alunoid, valor, dataPagamento, mesReferencia) { }
        public Pagamento(decimal valor, string dataPagamento, string mesReferencia) : base(valor, dataPagamento, mesReferencia) { }
    }
}
