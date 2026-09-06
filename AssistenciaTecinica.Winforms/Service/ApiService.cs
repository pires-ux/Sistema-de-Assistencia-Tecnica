using AssistenciaWinForms.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ex04
{
    internal class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
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


        //Login
        public async Task<bool> Login(LoginClienteDTO login)
        {
            string json = JsonSerializer.Serialize(login);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("http://localhost:5156/Cliente/login", content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                string erro = await response.Content.ReadAsStringAsync();
                return false;
            }
        }
    }
}
