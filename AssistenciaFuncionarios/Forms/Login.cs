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
                Login.ActiveForm.Hide();
                TelaPrincipal tela = new TelaPrincipal();
                tela.Show();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login.ActiveForm.Hide();
            Cadastro cadastro = new Cadastro();
            cadastro.Show();
        }
    }
}
