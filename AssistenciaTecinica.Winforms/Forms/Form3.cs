
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
        List<Serviço> serviços = new List<Serviço>();
        ClienteApi apiService = new ClienteApi();
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
            MessageBox.Show(dia.ToString());
            Serviço serviço = new Serviço()
            {
                Id = 0,
                Aparelho = item,
                Descrição = descrição,
                Data = dia,
                Status = "Aberto",
                Valor = 0,
                Cliente = _cliente
            };
            MessageBox.Show(await apiService.CriarServiço(serviço));
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
            listBox1.Items.Clear();
            serviços = await apiService.GetServiço(_cliente.id);
            foreach (var item in serviços)
            {
                listBox1.Items.Add(item.ToString());
            }
        }
    }
}
