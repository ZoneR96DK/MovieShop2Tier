using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MovieShopDLL.ServiceGateways
{
    internal class CustomerServiceGateway : AbstractServiceGateway<Customer>
    {
        private static CustomerServiceGateway _instance;

        private CustomerServiceGateway()
        {
        }

        public static CustomerServiceGateway Instance => _instance ?? (_instance = new CustomerServiceGateway());

        public override Customer Create(HttpClient client, Customer customer)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("api/customers", customer).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Customer>().Result;
            }
            return null;
        }

        public override Customer Read(HttpClient client, int id)
        {
            HttpResponseMessage response = client.GetAsync($"api/customers/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Customer>().Result;
            }
            return null;
        }

        public override List<Customer> Read(HttpClient client)
        {
            var response = client.GetAsync("/api/customers").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<Customer>>().Result;
            }
            return new List<Customer>();
        }

        public override Customer Update(HttpClient client, Customer customer)
        {
            HttpResponseMessage response = client.PutAsJsonAsync($"api/products/{customer.Id}", customer).Result;
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Customer>().Result;
            }
            return null;
        }

        public override void Delete(HttpClient client, int id)
        {
            HttpResponseMessage response = client.DeleteAsync($"api/customer/{id}").Result;
        }
    }
}