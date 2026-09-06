using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistenciaFuncionarios.DTO
{
    internal class AtualizarServicoDTO
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public string Status { get; set; }

        public AtualizarServicoDTO(int id, decimal valor, string status)
        {
            Id = id; 
            Valor = valor;
            Status = status;
        }

        public override string ToString()
        {
            return $"{Id}, {Valor}, {Status}";
        }
    }
}
