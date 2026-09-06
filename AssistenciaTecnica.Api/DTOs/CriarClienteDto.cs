namespace AssistenciaApi.DTOs
{
    public class CriarClienteDto
    {
        public CriarClienteDto() { }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }


        public CriarClienteDto(int id, string nome, string telefone, string email)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Email = email;
        }
    }
}
