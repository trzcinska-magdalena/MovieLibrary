using MovieLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieLibrary.Api
{
    public class MovieApi
    {
        private readonly string _apiKey = "548d4c20";
        private HttpClient _httpClient = new HttpClient();

        public MovieApi() { }

        public async Task<Movie> GetMovie(string titleMovie)
        {
            titleMovie = titleMovie.Replace(" ", "+");
            string path = $"https://www.omdbapi.com/?apikey={_apiKey}&t={titleMovie}";

            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(path);

            if (!httpResponseMessage.IsSuccessStatusCode)
                throw new NullReferenceException();

            Movie movie = JsonConvert.DeserializeObject<Movie>(await httpResponseMessage.Content.ReadAsStringAsync())
            return movie;
        }
    }
}
