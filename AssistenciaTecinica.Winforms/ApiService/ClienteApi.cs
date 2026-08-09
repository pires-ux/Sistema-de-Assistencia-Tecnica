using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ex04
{
    internal class ClienteApi
    {
        private readonly HttpClient _httpClient;

        public ClienteApi()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Cliente>> GetClientes()//encontrar todos os clientes
        {
            HttpResponseMessage response = await _httpClient.GetAsync("http://localhost:5156/Cliente");
            string jsonResponse = await response.Content.ReadAsStringAsync();
            List<Cliente> clientes = JsonSerializer.Deserialize<List<Cliente>>(jsonResponse);
            return clientes;
        }

        public async Task<bool> GetClienteById(int id)//encontrar cliente pelo id
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"http://localhost:5156/Cliente/{id}");
            string jsonResponse = await response.Content.ReadAsStringAsync();
            Cliente cliente = JsonSerializer.Deserialize<Cliente>(jsonResponse);

            if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

            return true;
        }

        public async Task<string> CreateCliente(Cliente cliente)//criar cliente
        {
            string json = JsonSerializer.Serialize(cliente);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("http://localhost:5156/Cliente", content);

            if (response.IsSuccessStatusCode)
            {
                return "Conta criada com sucesso.";
            }
            else
            {
                string erro = await response.Content.ReadAsStringAsync();
                return $"Erro: {(int)response.StatusCode}\n{erro}";
            }

        }

        public async Task<bool> UpdateCliente(int id, Cliente cliente)//atualizar cliente
        {
            string json = JsonSerializer.Serialize(cliente);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync($"http://localhost:5156/Cliente/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



       
    }
}
