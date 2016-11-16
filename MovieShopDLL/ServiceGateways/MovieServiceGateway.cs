using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopDLL.ServiceGateways
{
    internal class MovieServiceGateway : AbstractServiceGateway<Movie>
    {
        private static MovieServiceGateway _instance;

        private MovieServiceGateway()
        {
        }

        public static MovieServiceGateway Instance => _instance ?? (_instance = new MovieServiceGateway());

        public override Movie Create(HttpClient client, Movie movie)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("api/movies", movie).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Movie>().Result;
            }
            return null;
        }

        public override Movie Read(HttpClient client, int id)
        {
            var response = client.GetAsync($"api/movies/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Movie>().Result;
            }
            return null;
        }

        public override List<Movie> Read(HttpClient client)
        {
            var response = client.GetAsync("/api/movies").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<Movie>>().Result;
            }
            return new List<Movie>();
        }

        public override Movie Update(HttpClient client, Movie movie)
        {
            throw new NotImplementedException();
        }

        public override void Delete(HttpClient client, int id)
        {
            throw new NotImplementedException();
        }
    }
}