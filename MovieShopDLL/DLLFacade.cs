using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;
using MovieShopDLL.ServiceGateways;

namespace MovieShopDLL
{
    public class DllFacade
    {
        public static IServiceGateway<Genre> GetGenreServiceGateway()
        {
            return GenreServiceGateway.Instance;
        }

        public static IServiceGateway<Movie> GetMovieServiceGateway()
        {
            return MovieServiceGateway.Instance;
        }

        public static IServiceGateway<Customer> GetCustomerServiceGateway()
        {
            return CustomerServiceGateway.Instance;
        }

        public static IServiceGateway<Order> GetOrderServiceGateway()
        {
            return OrderServiceGateway.Instance;
        }

        public static IServiceGateway<Address> GetAddressServiceGateway()
        {
            return AddressServiceGateway.Instance;
        }
    }
}
