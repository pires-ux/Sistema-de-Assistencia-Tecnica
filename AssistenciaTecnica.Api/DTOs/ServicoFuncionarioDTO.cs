namespace AssistenciaApi.DTOs
{
    public class ServicoFuncionarioDTO
    {
        public ServicoFuncionarioDTO()
        {

        }

        public string Cliente { get; set; }
        public string Aparelho { get; set; }
        public decimal Valor { get; set; }
        public string Status { get; set; }
    }
}
