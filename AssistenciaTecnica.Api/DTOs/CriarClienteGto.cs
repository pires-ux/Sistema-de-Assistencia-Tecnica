namespace AssistenciaApi.DTOs
{
    public class CriarClienteGto
    {
        public CriarClienteGto() { }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }


        public CriarClienteGto(int id, string nome, string telefone, string cpf, string endereco)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Cpf = cpf;
            Endereco = endereco;
        }
    }
}
