using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;
using MovieShopDLL.Repositories;

namespace MovieShopDLL
{
    public class DllFacade
    {
        public static IRepository<Genre> GetGenreRepository()
        {
            return GenreRepository.Instance;
        }

        public static IRepository<Movie> GetMovieRepository()
        {
            return MovieRepository.Instance;
        }

        public static IRepository<Customer> GetCustomerRepository()
        {
            return CustomerRepository.Instance;
        }

        public static IRepository<Order> GetOrderRepository()
        {
            return OrderRepository.Instance;
        }

        public static IRepository<Address> GetAddressRepository()
        {
            return AddressRepository.Instance;
        }
    }
}
