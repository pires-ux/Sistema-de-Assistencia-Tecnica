using AssistenciaFuncionarios.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
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
                return null;
            }
            var json = await response.Content.ReadAsStringAsync();
            var servico = JsonSerializer.Deserialize<List<ServicoDTO>>(json);

            return servico;

        }
    }
}
