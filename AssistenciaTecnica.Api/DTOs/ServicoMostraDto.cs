namespace AssistenciaApi.DTOs
{
    public class ServicoMostraDto
    {
        public ServicoMostraDto() { }

        public string Aparelho { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Status { get; set; }


        public override string ToString()
        {
            return $"Aparelho: {Aparelho}, Descricao: {Descricao}, Valor: {Valor}, Status: {Status}";
        }
    }
}
