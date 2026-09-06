
using AssistenciaWinForms.ApiService;
using AssistenciaWinForms.DTOs;
using System.Collections.Generic;

namespace ex04
{
    public partial class Form3 : Form
    {
        Cliente _cliente;
        public Form3(Cliente cliente)
        {
            InitializeComponent();
            _cliente = cliente;
        }
        List<ServicoDTO> serviços = new List<ServicoDTO>();
        ServiceApi ServiceApi = new ServiceApi();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            listar();
        }

        public async void listar()
        {
            serviços.Clear();
            dataGridView1.Rows.Clear();
            serviços = await ServiceApi.GetServiço(_cliente.id);
            foreach (var item in serviços)
            {
                dataGridView1.Rows.Add(item.Aparelho, item.Descricao, item.Data, item.Valor, item.Status);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
