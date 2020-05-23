using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ControleDeFuncionario.config
{
    class ConectaBD
    {
        private static string serverName = "localhost";
        private static string port = "5432";
        private static string userName = "postgres";
        private static string password = "2416";
        private static string dataBaseName = "dbveiculos";



        public NpgsqlConnection getConexao()
        {
            string stgConexao = String.Format("Server={0};Port={1};" +
              "User Id={2};Password={3};Database={4};",
                serverName, port, userName, password, dataBaseName);


            NpgsqlConnection conexao = new NpgsqlConnection(stgConexao);
            conexao.Open();
            return conexao;
        }
    }
}
