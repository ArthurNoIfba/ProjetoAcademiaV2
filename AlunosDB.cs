using ProjetoAcademia.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ProjetoAcademia.Data
{
    public class AlunosDB
    {
        private string conn;

        public AlunosDB(IConfiguration configuration)
        {
            conn = configuration.GetConnectionString("Banco")
                ?? throw new InvalidOperationException(
                    "String de conexão 'Banco' não foi encontrada");
        }

        public SQLiteConnection CriarConexao()
        {
            return new SQLiteConnection(conn);
        }

        public int Incluir(Aluno aluno)
        {
            string sql = @"
                INSERT INTO Aluno
                    (Nome, Email, Telefone, DataMatricula)
                VALUES
                    (@pNome, @pEmail, @pTelefone, @pDataMatricula)";

            using (SQLiteConnection conexao = CriarConexao())
            using (SQLiteCommand comando = new SQLiteCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@pNome", aluno.Nome);
                comando.Parameters.AddWithValue("@pEmail", aluno.Email);
                comando.Parameters.AddWithValue("@pTelefone", aluno.Telefone);
                comando.Parameters.AddWithValue(
                    "@pDataMatricula", aluno.DataMatricula);

                conexao.Open();
                int linhas = comando.ExecuteNonQuery();

                return linhas;
            }
        }

        public int Incluir(Alunos alunos)
        {
            return Incluir((Aluno)alunos);
        }

        public List<Aluno> Listar()
        {
            List<Aluno> alunos = new List<Aluno>();

            string sql = @"
                SELECT IdAluno, Nome, Email, Telefone, DataMatricula
                FROM Aluno
                ORDER BY Nome";

            using (SQLiteConnection conexao = CriarConexao())
            using (SQLiteCommand comando = new SQLiteCommand(sql, conexao))
            {
                conexao.Open();

                using (SQLiteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        Aluno aluno = new Aluno();

                        aluno.IdAluno = leitor.GetInt32(0);
                        aluno.Nome = leitor.GetString(1);
                        aluno.Email = leitor.GetString(2);
                        aluno.Telefone = leitor.GetString(3);
                        aluno.DataMatricula = leitor.GetString(4);

                        alunos.Add(aluno);
                    }
                }
            }

            return alunos;
        }
    }
}