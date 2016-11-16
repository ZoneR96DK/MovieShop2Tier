using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopDLL.ServiceGateways
{
    internal class AddressServiceGateway : AbstractServiceGateway<Address>
    {
        private static AddressServiceGateway _instance;

        private AddressServiceGateway()
        {
        }

        public static AddressServiceGateway Instance => _instance ?? (_instance = new AddressServiceGateway());

        public override Address Create(HttpClient client, Address address)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("api/addresss", address).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Address>().Result;
            }
            return null;
        }

        public override Address Read(HttpClient client, int id)
        {
            var response = client.GetAsync($"api/addresss/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Address>().Result;
            }
            return null;
        }

        public override List<Address> Read(HttpClient client)
        {
            var response = client.GetAsync("/api/addresss").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<Address>>().Result;
            }
            return new List<Address>();
        }

        public override Address Update(HttpClient client, Address address)
        {
            throw new NotImplementedException();
        }

        public override void Delete(HttpClient client, int id)
        {
            throw new NotImplementedException();
        }
    }
}