using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoAcademia.Data;
using ProjetoAcademia.Models;
using System.Globalization;

namespace ProjetoAcademia.Pages
{
    public class AlunosModel : PageModel
    {
        private readonly AlunosDB _alunosDB;
        public string Mensagem { get; set; } = "";
        public void OnGet()
        {
        }     
        public AlunosModel(AlunosDB alunosDB)
        {
            _alunosDB = alunosDB;
        }
        public void OnPost()
        {
            string nome = Request.Form["nome"].ToString();
            string cpf = Request.Form["cpf"].ToString();
            string plano = Request.Form["plano"].ToString();
            int dataMatricula = int.Parse(Request.Form["dataMatricula"].ToString());

            Alunos alunos = new Alunos(nome, cpf, plano, dataMatricula);
            int quant = _alunosDB.Incluir(alunos);
            Mensagem = quant > 0 ? "Aluno incluído com sucesso!" : "Erro ao incluir aluno.";

        }
    }
}