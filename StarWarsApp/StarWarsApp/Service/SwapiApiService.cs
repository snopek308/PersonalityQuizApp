using Newtonsoft.Json;
using StarWarsApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsApp.Service
{
    class SwapiApiService
    {
        string baseUrl = "https://swapi.dev/api/";
        private HttpClient _httpClient;

        public SwapiApiService(HttpClient httpClient)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<StarWarsCharacter> GetStarWarsCharacter(string path)
        {
            var response = await _httpClient.GetAsync(this.baseUrl + path);
            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();
            StarWarsCharacter character = JsonConvert.DeserializeObject<StarWarsCharacter>(resp);
            return character;
        }

    }
}
