
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

        Aparelho aparelho = new Aparelho();
        List<ServicoDTO> serviços = new List<ServicoDTO>();
        ServiceApi ServiceApi = new ServiceApi();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(aparelho.GetType().GetEnumNames());
            listar();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            aparelho = comboBox1.SelectedItem.ToString() switch
            {
                "Celular" => Aparelho.Celular,
                "Impressora" => Aparelho.Impressora,
                "Notebook" => Aparelho.Notebook,
                "Computador" => Aparelho.Computador,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string nome = _cliente.nome;
            string descrição = textBox1.Text;
            string item = aparelho.ToString();
            DateTime data = DateTime.Now;
            DateOnly dia = DateOnly.FromDateTime(data);
            Serviço serviço = new Serviço()
            {
                Id = 0,
                ClienteId = _cliente.id,
                Aparelho = item,
                Descrição = descrição,
                Data = dia,
                Status = "Aberto",
                Valor = 0,
            };
            MessageBox.Show(await ServiceApi.CriarServiço(serviço));
            listar();
            

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public enum Aparelho
        {
            Celular,
            Impressora,
            Notebook,
            Computador
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
