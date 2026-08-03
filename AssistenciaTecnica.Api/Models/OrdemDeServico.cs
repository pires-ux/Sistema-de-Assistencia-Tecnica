namespace Api4
{
    public class OrdemDeServico
    {
        public OrdemDeServico()
        {

        }

        public int Id { get; set; }
        public string Aparelho { get; set; }
        public string Descrição { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        public decimal Valor { get; set; }
        public int ClienteId { get; set; } 
        public Cliente? Cliente { get; set; }

        public OrdemDeServico(int id, string aparelho, string descrição, DateTime data, string status, decimal valor)
        {
            Id = id;
            Aparelho = aparelho;
            Descrição = descrição;
            Data = data;
            Status = status;
            Valor = valor;
        }


    }
}
