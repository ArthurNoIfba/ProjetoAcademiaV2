using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoAcademia.Data;
using ProjetoAcademia.Models;

namespace ProjetoAcademia.Pages
{
    public class PagamentosModel : PageModel
    {

        private readonly PagamentosDB _pagamentosDB;
        public string Mensagem { get; set; } = "";
        public void OnGet()
        {
        }

        public PagamentosModel(PagamentosDB pagamentosDB)
        {
            _pagamentosDB = pagamentosDB;
        }

        public void OnPost()
        {
            decimal valor = decimal.Parse(Request.Form["valor"].ToString(), CultureInfo.InvariantCulture);
            string dataPagamento = Request.Form["dataPagamento"].ToString();
            string mesReferencia = Request.Form["mesReferencia"].ToString();
            
            Pagamentos pagamentos = new Pagamentos(valor, dataPagamento, mesReferencia);
            int quant = _pagamentosDB.Incluir(pagamentos);
            Mensagem = quant > 0 ? "Pagamento incluído com sucesso!" : "Erro ao incluir pagamento.";

        }
    }
}