using ControleDeFuncionario.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeFuncionario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                Funcionario func = new Funcionario();
                func.Nome = txtNome.Text;
                func.Email = txtEmail.Text;

                func.Cadastrar();

                MessageBox.Show("Cadastrado com Sucesso!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar. " + ex.Message);
            }
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            Funcionario func = new Funcionario();
            dgvFuncionario.DataSource = func.Listar();
        }
    }
}
