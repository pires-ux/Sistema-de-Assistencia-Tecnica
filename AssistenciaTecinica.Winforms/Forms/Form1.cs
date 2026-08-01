using ex04;
using System.Collections.Generic;

namespace Ex04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ApiService service = new ApiService();
        List<Cliente> clientes = new List<Cliente>();
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2();
            Form1.ActiveForm.Hide();
            form2.Show();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string nome = textBox1.Text;
            string telefone = textBox2.Text;
            string cpf = textBox3.Text;
            string endereco = textBox4.Text;

            Cliente cliente = new Cliente(0, nome, telefone, cpf, endereco)
            {
                Serviços = new List<Serviço>()
            };

            MessageBox.Show(await service.CreateCliente(cliente));
        }

        public async void ListarClientes()
        {
            foreach (var cliente in await service.GetClientes())
            {
                clientes.Add(cliente);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListarClientes();
        }
    }
}
