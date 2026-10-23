using ProjetoAcademia.Models;

namespace ProjetoAcademia.Models
{
    public class Pagamentos
    {
        public int Pagamentoid { get; set; }
        public int IdPagamento { get; set; }
        public int Alunoid { get; set; }
        public int IdAluno { get; set; }
        public decimal Valor { get; set; }
        public string DataPagamento { get; set; } = string.Empty;
        public string MesReferencia { get; set; } = string.Empty;
        public string FormaPagamento { get; set; } = string.Empty;

        public Pagamentos()
        {
        }

        public Pagamentos(int pagamentoid)
        {
            Pagamentoid = pagamentoid;
        }

        public Pagamentos(int alunoid, decimal valor, string dataPagamento, string mesReferencia)
        {
            Alunoid = alunoid;
            Valor = valor;
            DataPagamento = dataPagamento;
            MesReferencia = mesReferencia;
        }

        public Pagamentos(decimal valor, string dataPagamento, string mesReferencia)
        {
            Valor = valor;
            DataPagamento = dataPagamento;
            MesReferencia = mesReferencia;
        }
    }
}