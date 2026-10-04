using AssistenciaFuncionarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistenciaFuncionarios.DTO
{
    public class CriarClienteComServicoDTO
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Cliente { get; set; }
        public string Aparelho { get; set; }
        public decimal Valor { get; set; }
        public DateOnly Data { get; set; }
        public string Status { get; set; }
        public string Telefone { get; set; }

        public Cliente cliente { get; set; }
    }
}
