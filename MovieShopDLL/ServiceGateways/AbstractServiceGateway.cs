using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopDLL.ServiceGateways
{
    internal abstract class AbstractServiceGateway<T> : IServiceGateway<T>
    {
        public T Create(T item)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52395/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                return Create(client, item);
            }
        }

        public T Read(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52395/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                return Read(client, id);
            }
        }

        public List<T> Read()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52395/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                return Read(client);
            }
        }

        public T Update(T item)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52395/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                return Update(client, item);
            }
        }

        public void Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52395/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                Delete(client, id);
            }
        }

        public abstract T Create(HttpClient client, T item);

        public abstract T Read(HttpClient client, int id);

        public abstract List<T> Read(HttpClient client);

        public abstract T Update(HttpClient client, T item);

        public abstract void Delete(HttpClient client, int id);
    }
}