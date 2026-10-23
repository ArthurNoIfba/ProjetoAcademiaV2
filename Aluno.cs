namespace ProjetoAcademia.Models
{
    public class Aluno : Alunos
    {
        public Aluno() { }
        public Aluno(string nome, string cpf, string plano, int alunoid) : base(nome, cpf, plano, alunoid) { }
        public Aluno(string nome, string cpf, string plano, string dataMatricula) : base(nome, cpf, plano, dataMatricula) { }
    }
}
