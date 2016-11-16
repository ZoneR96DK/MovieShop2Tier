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
    public class MovieServiceGateway //: AbstractServiceGateway<Movie>
    {
        private static MovieServiceGateway _instance;

        private MovieServiceGateway()
        {
        }

        public static MovieServiceGateway Instance => _instance ?? (_instance = new MovieServiceGateway());

        public Movie Create(Movie movie)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52395/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsJsonAsync("api/movies", movie).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Movie>().Result;
                }
                return null;
            }
        }

        public Movie Read(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52395/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync($"api/movies/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Movie>().Result;
                }
                return null;
            }
        }

        public List<Movie> Read()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52395/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync("/api/movies").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<Movie>>().Result;
                }
            }
            return new List<Movie>();
        }

        //public Movie Update(Movie movie)
        //{
        //    db.Entry(movie).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return movie;
        //}

        //public void Delete(int id)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:1922/");
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(
        //            new MediaTypeWithQualityHeaderValue("application/json"));

        //        var response = client.DeleteAsync($"/api/movies/{id}").Result;
        //        if (response.IsSuccessStatusCode)
        //        {
        //            return response.Content.ReadAsAsync<Movie>().Result != null;
        //        }
        //        return false;
        //    }
        //}
    }
}