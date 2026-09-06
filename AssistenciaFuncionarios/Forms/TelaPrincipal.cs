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
        
        bool editado = false;
        private async void TelaPrincipal_Load(object sender, EventArgs e)
        {
            await Listar();
        }

        public async Task Listar()
        {
            dataGridView1.Rows.Clear();
            List<ServicoDTO> servicos = await api.ServicoListar();
            foreach (var serv in servicos)
            {
                dataGridView1.Rows.Add(serv.Id, serv.Cliente, serv.Aparelho, serv.Data, serv.Valor,  serv.Status);                
            }

        }

        private async void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {          
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
            var valor = dataGridView1.Rows[e.RowIndex].Cells["Valor"].Value.ToString();
            var status = dataGridView1.Rows[e.RowIndex].Cells["Status"].Value.ToString();
            AtualizarServicoDTO servicoDTO = new AtualizarServicoDTO(id, Convert.ToDecimal(valor), status);
            if (await api.Atualizar(servicoDTO))
            {

            }
            else
            {
                MessageBox.Show("erro ao atualizar serviço");
            }

        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ClearSelection(); 
        }
    }
}
