using Microsoft.Extensions.Configuration;
using SportEvents.Contracts;
using SportEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SportEvents.Services
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        public HttpCommandDataClient(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }
        public async Task SendEventToCommandAsync(EventResponseDTO eventResponseDTO)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(eventResponseDTO),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync(_config["CommandService"], httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("event successful.");
            }
            else
            {
                Console.WriteLine("event failed.");
            }
        }
    }
}
