using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopDLL.ServiceGateways
{
    internal class GenreServiceGateway : AbstractServiceGateway<Genre>
    {
        private static GenreServiceGateway _instance;

        private GenreServiceGateway()
        {
        }

        public static GenreServiceGateway Instance => _instance ?? (_instance = new GenreServiceGateway());

        public override Genre Create(HttpClient client, Genre genre)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("api/genres", genre).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Genre>().Result;
            }
            return null;
        }

        public override Genre Read(HttpClient client, int id)
        {
            var response = client.GetAsync($"api/genres/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Genre>().Result;
            }
            return null;
        }

        public override List<Genre> Read(HttpClient client)
        {
            var response = client.GetAsync("/api/genres").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<Genre>>().Result;
            }
            return new List<Genre>();
        }

        public override Genre Update(HttpClient client, Genre genre)
        {
            throw new NotImplementedException();
        }

        public override void Delete(HttpClient client, int id)
        {
            throw new NotImplementedException();
        }
    }
}