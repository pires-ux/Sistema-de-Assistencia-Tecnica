using System;
using System.Collections.Generic;
using System.Text;

namespace ex04
{
    public class Serviço
    {
        public Serviço()
        {

        }
        public int Id { get; set; }
        public string Aparelho { get; set; }
        public string Descrição { get; set; }
        public DateOnly Data { get; set; }
        public string Status { get; set; }
        public decimal Valor {  get; set; }
        public int ClienteId { get; set; }

        public Serviço(int id, string aparelho, string descrição, DateOnly data, string status, decimal valor)
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
