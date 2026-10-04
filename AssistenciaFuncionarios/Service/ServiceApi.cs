 using AssistenciaFuncionarios.DTO;
using AssistenciaFuncionarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AssistenciaFuncionarios.Service
{
    internal class ServiceApi
    {
        private readonly HttpClient _http;
        public ServiceApi()
        {
            _http = new HttpClient();
        }

        public async Task<bool> Login(LoginFuncionarioDTO login)
        {
            string json = JsonSerializer.Serialize(login);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _http.PostAsync($"http://localhost:5156/Funcionario/Login", content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public async Task<bool> Cadastro(CadastroFuncionarioDTO cadastro)
        {
            string json = JsonSerializer.Serialize(cadastro);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _http.PostAsync("http://localhost:5156/Funcionario", content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<ServicoDTO>> ServicoListar()
        {
            HttpResponseMessage response = await _http.GetAsync("http://localhost:5156/Problema/Funcionario");
            if (!response.IsSuccessStatusCode)
            {
                return new List<ServicoDTO>();
            }
            var json = await response.Content.ReadAsStringAsync();
            var opções = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var servico = JsonSerializer.Deserialize<List<ServicoDTO>>(json, opções);
            return servico;

        }    

        public async Task<bool> Atualizar(AtualizarServicoDTO servico)
        {
            var json = JsonSerializer.Serialize(servico);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _http.PatchAsync($"http://localhost:5156/Problema/Atualizar", content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<Cliente> AdicionarCliente(Cliente cliente)
        {
            string json = JsonSerializer.Serialize(cliente);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _http.PostAsync($"http://localhost:5156/Cliente/Criar", content);
            var ResponseJson = await response.Content.ReadAsStringAsync();
            var opções = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var result = JsonSerializer.Deserialize<Cliente>(ResponseJson, opções);
            return result;
        }

        public  async Task<bool> CriarClienteComServico(CriarClienteComServicoDTO dados)
        {
            string json = JsonSerializer.Serialize(dados);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _http.PostAsync($"http://localhost:5156/Cliente/CriarComServico", content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false; 
        }
    }
}
