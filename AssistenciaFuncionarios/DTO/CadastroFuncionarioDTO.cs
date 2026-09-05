using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistenciaFuncionarios.DTO
{
    internal class CadastroFuncionarioDTO
    {
        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Senha { get; set; } = string.Empty;
    }
}
