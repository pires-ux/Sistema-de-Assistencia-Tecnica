namespace Api4
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public long Telefone { get; set; }
        public long Cpf { get; set; }
        public string Endereco { get; set; }


        public Usuario(int id, string nome, long telefone, long cpf, string endereco)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Cpf = cpf;
            Endereco = endereco;
        }
    }
}
