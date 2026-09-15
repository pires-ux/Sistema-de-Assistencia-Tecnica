using AssistenciaFuncionarios.DTO;
using AssistenciaFuncionarios.Forms;
using AssistenciaFuncionarios.Models;
using AssistenciaFuncionarios.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssistenciaFuncionarios.Forms
{
    public partial class CadastrarServico : Form
    {
        Cliente _cliente;
        public CadastrarServico(Cliente cliente)
        {
            InitializeComponent();
            _cliente = cliente;
        }
        ServiceApi api = new ServiceApi();
        private void CadastrarServico_Load(object sender, EventArgs e)
        {

        }


        private async void button1_Click_1(object sender, EventArgs e)
        {
            string aparelho = textBox1.Text;
            string defeito = textBox2.Text;
            decimal valor = Convert.ToDecimal(textBox3.Text);
            var data = DateTime.Now;
            DateOnly dateOnly = DateOnly.FromDateTime(data);
            ServicoDTO servico = new ServicoDTO
            {
                Id = 0,
                ClienteId = _cliente.Id,
                Cliente = _cliente.Nome,
                Aparelho = aparelho,
                Valor = valor,
                Data = dateOnly,
                Status = "Em Analise",
                Telefone = _cliente.Telefone
            };

            if (await api.CriarServico(servico))
            {
                this.Hide();
                TelaPrincipal form = new TelaPrincipal();
                form.Show();
            }
            else
            {
                MessageBox.Show("erro ao adicionar servico");
            }
        }
    }
}
