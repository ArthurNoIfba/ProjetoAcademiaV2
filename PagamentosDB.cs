using Microsoft.Extensions.Configuration;
using ProjetoAcademia.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ProjetoAcademia.Data
{
    public class PagamentosDB
    {
        private string conn;

        public PagamentosDB(IConfiguration configuration)
        {
            conn = configuration.GetConnectionString("Banco")
                ?? throw new InvalidOperationException(
                    "String de conexão 'Banco' não foi encontrada");
        }

        public SQLiteConnection CriarConexao()
        {
            return new SQLiteConnection(conn);
        }

        public int Incluir(Pagamento pagamento)
        {
            string sql = @"
                INSERT INTO Pagamento
                    (IdAluno, Valor, DataPagamento, FormaPagamento)
                VALUES
                    (@pIdAluno, @pValor, @pDataPagamento, @pFormaPagamento)";

            using (SQLiteConnection conexao = CriarConexao())
            using (SQLiteCommand comando = new SQLiteCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@pIdAluno", pagamento.IdAluno);
                comando.Parameters.AddWithValue("@pValor", pagamento.Valor);
                comando.Parameters.AddWithValue(
                    "@pDataPagamento", pagamento.DataPagamento);
                comando.Parameters.AddWithValue(
                    "@pFormaPagamento", pagamento.FormaPagamento);

                conexao.Open();
                int linhas = comando.ExecuteNonQuery();

                return linhas;
            }
        }

        public int Incluir(Pagamentos pagamentos)
        {
            Pagamento pagamento = new Pagamento(
                pagamentos.Alunoid,
                pagamentos.Valor,
                pagamentos.DataPagamento,
                pagamentos.MesReferencia
            )
            {
                FormaPagamento = pagamentos.FormaPagamento
            };

            return Incluir(pagamento);
        }

        public List<Pagamento> Listar()
        {
            List<Pagamento> pagamentos = new List<Pagamento>();

            string sql = @"
                SELECT IdPagamento, IdAluno, Valor, DataPagamento, FormaPagamento
                FROM Pagamento
                ORDER BY DataPagamento DESC";

            using (SQLiteConnection conexao = CriarConexao())
            using (SQLiteCommand comando = new SQLiteCommand(sql, conexao))
            {
                conexao.Open();

                using (SQLiteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        Pagamento pagamento = new Pagamento();

                        pagamento.IdPagamento = leitor.GetInt32(0);
                        pagamento.IdAluno = leitor.GetInt32(1);
                        pagamento.Valor = leitor.GetDecimal(2);
                        pagamento.DataPagamento = leitor.GetString(3);
                        pagamento.FormaPagamento = leitor.GetString(4);

                        pagamentos.Add(pagamento);
                    }
                }
            }

            return pagamentos;
        }

        public List<Pagamento> ListarPorAluno(int idAluno)
        {
            List<Pagamento> pagamentos = new List<Pagamento>();

            string sql = @"
                SELECT IdPagamento, IdAluno, Valor, DataPagamento, FormaPagamento
                FROM Pagamento
                WHERE IdAluno = @pIdAluno
                ORDER BY DataPagamento DESC";

            using (SQLiteConnection conexao = CriarConexao())
            using (SQLiteCommand comando = new SQLiteCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@pIdAluno", idAluno);
                conexao.Open();

                using (SQLiteDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        Pagamento pagamento = new Pagamento();

                        pagamento.IdPagamento = leitor.GetInt32(0);
                        pagamento.IdAluno = leitor.GetInt32(1);
                        pagamento.Valor = leitor.GetDecimal(2);
                        pagamento.DataPagamento = leitor.GetString(3);
                        pagamento.FormaPagamento = leitor.GetString(4);

                        pagamentos.Add(pagamento);
                    }
                }
            }

            return pagamentos;
        }
    }
}