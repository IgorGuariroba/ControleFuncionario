using ControleDeFuncionario.config;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeFuncionario.Modelo
{
    class Funcionario
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public string Email {get; set; }


        public Funcionario()
        {

        }

        public Funcionario(int id, string nome, string email)
        {

            this.Id = id;
            this.Nome = nome;
            this.Email = email;

        }

        public void Cadastrar()
        {
            try
            {
                NpgsqlConnection con = new ConectaBD().getConexao();

                string sql = "INSERT INTO funcionarios (nome, email)" +
                    "VALUES ('" + this.Nome + "','" + this.Email + "')";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public List<Funcionario> Listar()
        {
            NpgsqlConnection conexao = new ConectaBD().getConexao();

            try
            {

                string sql = "SELECT * FROM funcionarios";

                NpgsqlCommand comand = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dr = comand.ExecuteReader();

                List<Funcionario> listaFuncionario = new List<Funcionario>();

                while (dr.Read())
                {
                    Funcionario novoFuncionario = new Funcionario();

                    novoFuncionario.Id = Convert.ToInt32(dr["id_funcionario"]);
                    novoFuncionario.Nome = dr["nome"].ToString();
                    novoFuncionario.Email = dr["email"].ToString();

                    listaFuncionario.Add(novoFuncionario);
                }

                return listaFuncionario;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (conexao != null)
                    conexao.Close();
            }

        }

    }

}
}
