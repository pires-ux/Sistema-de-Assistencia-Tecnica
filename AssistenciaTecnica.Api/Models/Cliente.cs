namespace Api4
{
    public class Cliente
    {
        public Cliente() { }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }


        public Cliente(int id, string nome, string telefone, string cpf, string endereco)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Cpf = cpf;
            Endereco = endereco;
        }
    }
}
