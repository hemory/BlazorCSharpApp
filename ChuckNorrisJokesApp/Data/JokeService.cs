using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ChuckNorrisJokesApp.Data
{
    public class JokeService
    {
        private readonly HttpClient _httpClient;

        public JokeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetRandomJokeAsync()
        {
            var response = await _httpClient.GetAsync("https://api.chucknorris.io/jokes/random");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                dynamic jokeObj = JsonConvert.DeserializeObject(content);
                return jokeObj.value;
            }
            else
            {
                return "Error: Failed to fetch a joke from the API.";
            }
        }
    }
}
