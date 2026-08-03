using AssistenciaWinForms.DTOs;
using ex04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace AssistenciaWinForms.ApiService
{
    internal class ServiceApi
    {
        private readonly HttpClient _httpClient;

        public ServiceApi()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<ServicoDTO>> GetServiço(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"http://localhost:5156/Problema/{id}");

            string json = await response.Content.ReadAsStringAsync();

            var opções = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<ServicoDTO> serviços = JsonSerializer.Deserialize<List<ServicoDTO>>(json, opções);

            if (response.IsSuccessStatusCode)
            {
                return serviços;

            }
            else
            {
                throw new Exception($"Erro ao listar serviços: {response.StatusCode}");
            }

        }

        public async Task<string> CriarServiço(Serviço serviço)
        {
            string json = JsonSerializer.Serialize(serviço);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("http://localhost:5156/Problema", content);

            if (response.IsSuccessStatusCode)
            {
                return "defeito mandado";
            }
            else
            {
                string erro = await response.Content.ReadAsStringAsync();
                return $"Erro: {(int)response.StatusCode}\n{erro}";
            }
        }
    }
}
