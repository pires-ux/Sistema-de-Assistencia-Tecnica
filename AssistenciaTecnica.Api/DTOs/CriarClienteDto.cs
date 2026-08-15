namespace AssistenciaApi.DTOs
{
    public class CriarClienteDto
    {
        public CriarClienteDto() { }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Senha { get; set; }


        public CriarClienteDto(int id, string nome, string telefone, string email, string endereco, string senha)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
            Senha = senha;
        }
    }
}
