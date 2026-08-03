

namespace AssistenciaWinForms.DTOs
{
    internal class ServicoDTO
    {
        public ServicoDTO() { }
        public string Aparelho { get; set; }
        public string Descricao { get; set; }
        public DateOnly Data { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public decimal Valor { get; set; }
        public string Status { get; set; }

        public ServicoDTO(string aparelho, string descricao, decimal valor, string status)
        {
            Aparelho = aparelho;
            Descricao = descricao;
            Valor = valor;
            Status = status;
        }

        public override string ToString()
        {
            return $"Aparelho: {Aparelho}, Descrição: {Descricao}, Valor: {Valor}, Status: {Status}";
        }
    }
}
