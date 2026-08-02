using ex04;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex04
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        ClienteApi apiService = new ClienteApi();
        List<Cliente> clientes = new List<Cliente>();
        private void button1_Click(object sender, EventArgs e)
        {
            string CPF = textBox1.Text;
            if (clientes.Exists(c => c.cpf == CPF))
            {
                Cliente cliente = clientes.Find(c => c.cpf == CPF);
                Form2.ActiveForm.Hide();
                Form3 form3 = new Form3(cliente);
                form3.Show();
                
            }
        }

        public async void ListarClientes()
        {
            clientes = await apiService.GetClientes();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ListarClientes();
        }

    }
}
