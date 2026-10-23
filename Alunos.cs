namespace ProjetoAcademia.Models
{
    public class Alunos
    {
        public int Alunoid { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Plano { get; set; } = string.Empty;
        public string DataMatricula { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public int IdAluno { get; set; }

        public Alunos()
        {
        }

        public Alunos(string nome, string cpf, string plano, int alunoid)
        {
            Nome = nome;
            Cpf = cpf;
            Plano = plano;
            Alunoid = alunoid;
        }

        public Alunos(string nome, string cpf, string plano, string dataMatricula)
        {
            Nome = nome;
            Cpf = cpf;
            Plano = plano;
            DataMatricula = dataMatricula;
        }
    }
}