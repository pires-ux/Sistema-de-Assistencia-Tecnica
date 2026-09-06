namespace Api4
{
    public class Cliente
    {
        public Cliente() { }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }


        public Cliente(int id, string nome, string telefone, string email)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Email = email;
        }

        public List<OrdemDeServico> Servico { get; set; } = new List<OrdemDeServico>();
    }
}
