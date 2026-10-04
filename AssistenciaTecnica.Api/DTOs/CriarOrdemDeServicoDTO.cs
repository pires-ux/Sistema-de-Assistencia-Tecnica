using Api4;

namespace AssistenciaApi.DTOs
{
    public class CriarOrdemDeServicoDTO
    {
        public int Id { get; set; }
        public string Aparelho { get; set; }
        public string Descrição { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        public decimal Valor { get; set; }
        public int ClienteId { get; set; }
        public CriarClienteDto Cliente { get; set; }
    }
}
