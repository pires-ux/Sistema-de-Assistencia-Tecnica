namespace Api4
{
    public class OrdemDeServiço
    {
        public OrdemDeServiço()
        {

        }

        public int Id { get; set; }
        public string Cliente { get; set; }
        public int IdCliente { get; set; }
        public string Aparelho { get; set; }
        public string Descrição { get; set; }
        public DateOnly Data { get; set; }
        public string Status { get; set; }
        public decimal Valor { get; set; }

        public OrdemDeServiço(int id, string cliente, int idcliente, string aparelho, string descrição, DateOnly data, string status, decimal valor)
        {
            Id = id;
            Cliente = cliente;
            IdCliente = idcliente;
            Aparelho = aparelho;
            Descrição = descrição;
            Data = data;
            Status = status;
            Valor = valor;
        }
    }
}
