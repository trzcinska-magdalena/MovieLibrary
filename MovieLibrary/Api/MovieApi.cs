using MovieLibrary.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MovieLibrary.Api
{
    interface IMovieApi
    {
        Task<Movie> GetMovie(string title);
        Task<MovieShort[]> GetMovies(string textbox);
    }
    public class MovieApi : IMovieApi
    {
        private readonly string _apiKey = "548d4c20";
        private HttpClient _httpClient = new HttpClient();

        public MovieApi() { }

        public async Task<Movie> GetMovie(string title)
        {
            title = title.Replace(" ", "+");
            string path = $"https://www.omdbapi.com/?apikey={_apiKey}&t={title}";

            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(path);

            if (!httpResponseMessage.IsSuccessStatusCode)
                throw new NullReferenceException();

            Movie movie = JsonConvert.DeserializeObject<Movie>(await httpResponseMessage.Content.ReadAsStringAsync());
            return movie;
        }

        public async Task<MovieShort[]> GetMovies(string textbox)
        {
            textbox = textbox.Replace(" ", "+");
            string path = $"https://www.omdbapi.com/?apikey={_apiKey}&s={textbox}";

            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(path);

            if (!httpResponseMessage.IsSuccessStatusCode)
                throw new NullReferenceException();

            var json = JsonConvert.DeserializeObject<dynamic>(await httpResponseMessage.Content.ReadAsStringAsync());
            Console.WriteLine(json);


            MovieShort[] movies = json.Search.ToObject<MovieShort[]>();
            return movies;
        }
    }
}
