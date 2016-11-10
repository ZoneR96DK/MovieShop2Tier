using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;
using MovieShopDLL.Managers;

namespace MovieShopDLL
{
    public class DllFacade
    {
        public static IManager<Genre> GetGenreManager()
        {
            return GenreManager.Instance;
        }

        public static IManager<Movie> GetMovieManager()
        {
            return MovieManager.Instance;
        }

        public static IManager<Customer> GetCustomerManager()
        {
            return CustomerManager.Instance;
        }

        public static IManager<Order> GetOrderManager()
        {
            return OrderManager.Instance;
        }

        public static IManager<Address> GetAddressManager()
        {
            return AddressManager.Instance;
        }
    }
}
