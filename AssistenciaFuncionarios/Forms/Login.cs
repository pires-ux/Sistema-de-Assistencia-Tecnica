using AssistenciaFuncionarios.Service;

namespace AssistenciaFuncionarios
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        ServiceApi api = new ServiceApi();

        private async void button1_Click(object sender, EventArgs e)
        {
            LoginFuncionarioDTO login = new LoginFuncionarioDTO
            {
                email = textBox1.Text,
                senha = textBox2.Text
            };

            if(await api.Login(login))
            {
                this.Hide();
                TelaPrincipal tela = new TelaPrincipal();
                tela.Show();
            }
            else
            {
                MessageBox.Show("email ou senha incorreta");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Cadastro cadastro = new Cadastro();
            cadastro.Show();
        }
    }
}
