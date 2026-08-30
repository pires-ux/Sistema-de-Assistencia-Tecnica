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
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        ServiceApi api = new ServiceApi();

        private async void TelaPrincipal_Load(object sender, EventArgs e)
        {
            await Listar();
        }

        public async Task Listar()
        {
            dataGridView1.Rows.Clear();
            List<ServicoDTO> servico = await api.ServicoListar();
            foreach(var serv in servico)
            {
                dataGridView1.Rows.Add(serv.Cliente, serv.Aparelho, serv.Valor, serv.Data, serv.Status);
               
            }
        }
    }
}
