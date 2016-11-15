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

        public static IServiceGateway<Movie> GetMovieManager()
        {
            return MovieServiceGateway.Instance;
        }

        public static IServiceGateway<Customer> GetCustomerManager()
        {
            return CustomerServiceGateway.Instance;
        }

        public static IServiceGateway<Order> GetOrderManager()
        {
            return OrderServiceGateway.Instance;
        }

        public static IServiceGateway<Address> GetAddressManager()
        {
            return AddressServiceGateway.Instance;
        }
    }
}
