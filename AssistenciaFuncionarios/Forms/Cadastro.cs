using AssistenciaFuncionarios.DTO;
using AssistenciaFuncionarios.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssistenciaFuncionarios
{
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
        }
        ServiceApi Api = new ServiceApi();

        private async void button1_Click(object sender, EventArgs e)
        {
            CadastroFuncionarioDTO cadastro = new CadastroFuncionarioDTO
            {
                Nome = textBox1.Text,
                Email = textBox2.Text,
                Senha = textBox3.Text
            };

            if(await Api.Cadastro(cadastro))
            {
                LoginFuncionarioDTO login = new LoginFuncionarioDTO
                {
                    email = cadastro.Email,
                    senha = cadastro.Senha
                }; 
                Cadastro.ActiveForm.Hide();
                TelaPrincipal tela = new TelaPrincipal();
                tela.Show();
            }
            else
            {
                MessageBox.Show("erro ao cadastrar funcionario");
            }
        }
    }
}
