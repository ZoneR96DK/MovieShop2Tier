using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopDLL.ServiceGateways
{
    internal class OrderServiceGateway : AbstractServiceGateway<Order>
    {
        private static OrderServiceGateway _instance;

        private OrderServiceGateway()
        {
        }

        public static OrderServiceGateway Instance => _instance ?? (_instance = new OrderServiceGateway());

        public override Order Create(HttpClient client, Order order)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("api/orders", order).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Order>().Result;
            }
            return null;
        }

        public override Order Read(HttpClient client, int id)
        {
            var response = client.GetAsync($"api/orders/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Order>().Result;
            }
            return null;
        }

        public override List<Order> Read(HttpClient client)
        {
            var response = client.GetAsync("/api/orders").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<Order>>().Result;
            }
            return new List<Order>();
        }

        public override Order Update(HttpClient client, Order order)
        {
            throw new NotImplementedException();
        }

        public override void Delete(HttpClient client, int id)
        {
            throw new NotImplementedException();
        }
    }
}