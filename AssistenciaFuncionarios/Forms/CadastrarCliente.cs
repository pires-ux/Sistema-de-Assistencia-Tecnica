using AssistenciaFuncionarios.DTO;
using AssistenciaFuncionarios.Models;
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

namespace AssistenciaFuncionarios.Forms
{
    public partial class CadastrarCliente : Form
    {
        public CadastrarCliente()
        {
            InitializeComponent();
        }
        ServiceApi api = new ServiceApi();
        private async void button1_Click(object sender, EventArgs e)
        {
            string nome = textBox1.Text;
            string telefone = textBox2.Text;
            string email = textBox3.Text;

            Cliente cliente = new Cliente
            {
                Id = 0,
                Nome = nome,
                Telefone = telefone,
                Email = email
            };
            var resultado = await api.AdicionarCliente(cliente);
            MessageBox.Show(resultado.ToString());
            if (resultado != null)
            {
                this.Hide();
                CadastrarServico form = new CadastrarServico(resultado);
                form.Show();
            }
            else
            {
                MessageBox.Show("erro ao adicionar cliente");
            }
        }
    }
}
