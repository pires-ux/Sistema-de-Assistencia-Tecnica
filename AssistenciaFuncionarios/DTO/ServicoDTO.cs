using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistenciaFuncionarios.DTO
{
    internal class ServicoDTO
    {
        public ServicoDTO()
        {

        }
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Aparelho { get; set; }
        public decimal Valor { get; set; }
        public DateOnly Data { get; set; }
        public string Status { get; set; }
        public string Telefone { get; set; }

        public override string ToString()
        {
            return $"{Id}";
        }
    }
}
