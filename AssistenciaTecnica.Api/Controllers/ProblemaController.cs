using Api4;
using AssistenciaApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProblemaController : ControllerBase
    {
        private readonly ServiceOrdem _service;

        public ProblemaController(ServiceOrdem service)
        {
            _service = service;
        }

        [HttpGet("{idcliente:int}")]
        public async Task<IActionResult> Get(int idcliente)
        {
            var servicos = await _service.ClienteListar(idcliente);
            return Ok(servicos);
        }

        [HttpPost("criar")]
        public async Task<IActionResult> Criar([FromBody] OrdemDeServico ordem)
        {
            if (ordem == null)
            {
                return BadRequest("Os dados da ordem são obrigatórios.");
            }

            await _service.Criar(ordem);
            return Ok("Ordem criada com sucesso!");
        }

        [HttpPatch("Atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarServicoDTO atualizar)
        {
            if (atualizar == null || atualizar.Id <= 0)
            {
                return BadRequest("Informe um ID válido para a ordem.");
            }

            var atualizada = await _service.AtualizarServico(atualizar);
            if (!atualizada)
            {
                return NotFound("Ordem de serviço não encontrada.");
            }

            return Ok("Serviço atualizado.");
        }

        [HttpGet("Funcionario")]
        public async Task<IActionResult> GetResult()
        {
            var servicos = await _service.FuncionarioListar();
            return Ok(servicos);
        }

        [HttpGet("Buscar/{id:int}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var servico = await _service.BuscarId(id);
            if (servico == null)
            {
                return NotFound("Ordem de serviço não encontrada.");
            }

            return Ok(servico);
        }
    }
}