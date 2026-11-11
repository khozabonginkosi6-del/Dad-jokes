using ChuckNorrisJokesApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using ChuckNorrisJokesApp.Models;
using System.Text;
using System.Text.Json;

namespace ChuckNorrisJokesApp.Services
{
    public class DadJokesApiHttpService : IDadJokesApiService
    {
        private HttpClient _httpClient;
        private IConfigurationService _configurationService;

        public DadJokesApiHttpService(IConfigurationService service)
        {
            _configurationService = service;

            _httpClient = new HttpClient();

            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<string> GetDadJokeAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_configurationService.DadJokesApiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();

                DadJoke _joke = JsonSerializer.Deserialize<DadJoke>(jsonContent);

                if (_joke != null && !string.IsNullOrEmpty(_joke.joke))
                {
                    return _joke.joke;
                }

                throw new Exception("Dad joke is null or empty.");
            }

            throw new Exception("Failed to retrieve dad joke.");
        }

    }
}
