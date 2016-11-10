using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using MovieShopDLL.Entities;

namespace MovieShopDLL.Context
{
    class MovieShopDbInitializer : CreateDatabaseIfNotExists<MovieShopContext>
    {
        protected override void Seed(MovieShopContext context)
        {
            IEnumerable<Genre> genres = new Genre[]
            {
                new Genre() {Name = "Action"},
                new Genre() {Name = "Adventure"},
                new Genre() {Name = "Animation"},
                new Genre() {Name = "Biography"},
                new Genre() {Name = "Comedy"},
                new Genre() {Name = "Crime"},
                new Genre() {Name = "Documentary"},
                new Genre() {Name = "Drama"},
                new Genre() {Name = "Family"},
                new Genre() {Name = "Fantasy"},
                new Genre() {Name = "Film-Noir"},
                new Genre() {Name = "History"},
                new Genre() {Name = "Horror"},
                new Genre() {Name = "Music"},
                new Genre() {Name = "Musical"},
                new Genre() {Name = "Mystery"},
                new Genre() {Name = "Romance"},
                new Genre() {Name = "Sci-Fi"},
                new Genre() {Name = "Sport"},
                new Genre() {Name = "Thriller"},
                new Genre() {Name = "War"},
                new Genre() {Name = "Western"},
                new Genre() {Name = "Other" }
            };
            
            IEnumerable<Movie> movies = new Movie[]
            {
                new Movie()
                {
                    Title = "The Shawshank Redemption",
                    Year = new DateTime(1994, 1, 1),
                    Price = 100,
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/M/MV5BODU4MjU4NjIwNl5BMl5BanBnXkFtZTgwMDU2MjEyMDE@._V1_UX182_CR0,0,182,268_AL_.jpg",
                    Genre = genres.FirstOrDefault(g => g.Name == "Crime")
                },
                new Movie()
                {
                    Title = "The Godfather",
                    Year = new DateTime(1972, 1, 1),
                    Price = 80,
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/M/MV5BMjEyMjcyNDI4MF5BMl5BanBnXkFtZTcwMDA5Mzg3OA@@._V1_UX182_CR0,0,182,268_AL_.jpg",
                    Genre = genres.FirstOrDefault(g => g.Name == "Crime")
                },
                new Movie()
                {
                    Title = "The Dark Knight",
                    Year = new DateTime(2008, 1, 1),
                    Price = 120,
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_UX182_CR0,0,182,268_AL_.jpg",
                    Genre = genres.FirstOrDefault(g => g.Name == "Action")
                },
                new Movie()
                {
                    Title = " Schindler's List",
                    Year = new DateTime(1993, 1, 1),
                    Price = 100,
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/M/MV5BMzMwMTM4MDU2N15BMl5BanBnXkFtZTgwMzQ0MjMxMDE@._V1_UX182_CR0,0,182,268_AL_.jpg",
                    Genre = genres.FirstOrDefault(g => g.Name == "Biography"),
                    TrailerUrl = "https://www.youtube.com/watch?v=M5FpB6qDGAE"
                },
                new Movie()
                {
                    Title = "12 Angry Men",
                    Year = new DateTime(1957, 1, 1),
                    Price = 80,
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/M/MV5BODQwOTc5MDM2N15BMl5BanBnXkFtZTcwODQxNTEzNA@@._V1_UX182_CR0,0,182,268_AL_.jpg",
                    Genre = genres.FirstOrDefault(g => g.Name == "Crime")
                },
                new Movie()
                {
                    Title = "Pulp Fiction",
                    Year = new DateTime(1994, 1, 1),
                    Price = 100,
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTkxMTA5OTAzMl5BMl5BanBnXkFtZTgwNjA5MDc3NjE@._V1_UX182_CR0,0,182,268_AL_.jpg",
                    Genre = genres.FirstOrDefault(g => g.Name == "Crime")
                }
            };

            IEnumerable<Customer> customers = new Customer[]
            {
                new Customer()
                {
                    FirstName = "Adam",
                    LastName = "First",
                    Email = "adam.first@mail.net",
                    Address = new Address()
                    {
                        StreetName = "First Street",
                        StreetNumber = "1",
                        City = "First City",
                        PostalCode = 1111,
                        Country = "First Country"
                    }
                },
                new Customer()
                {
                    FirstName = "Bill",
                    LastName = "Second",
                    Email = "bill.second@mail.net",
                    Address = new Address()
                    {
                        StreetName = "Second Street",
                        StreetNumber = "2",
                        City = "Second City",
                        PostalCode = 2222,
                        Country = "Second Country"
                    }
                },
                new Customer()
                {
                    FirstName = "Clare",
                    LastName = "Third",
                    Email = "clare.third@mail.net",
                    Address = new Address()
                    {
                        StreetName = "Third Street",
                        StreetNumber = "3",
                        City = "Third City",
                        PostalCode = 3333,
                        Country = "Third Country"
                    }
                },
                new Customer()
                {
                    FirstName = "David",
                    LastName = "Fourth",
                    Email = "david.forth@mail.net",
                    Address = new Address()
                    {
                        StreetName = "Fourth Street",
                        StreetNumber = "4",
                        City = "Fourth City",
                        PostalCode = 4444,
                        Country = "Fourth Country"
                    }
                }
            };

            IEnumerable<Order> orders = new Order[]
            {
                new Order()
                {
                    CustomerId = 1,
                    MovieId = 1,
                    Date = DateTime.Today
                },
                new Order()
                {
                    CustomerId = 2,
                    MovieId = 2,
                    Date = DateTime.Today
                },
                new Order()
                {
                    CustomerId = 3,
                    MovieId = 3,
                    Date = DateTime.Today
                },
            };

            context.Genres.AddRange(genres);
            context.Movies.AddRange(movies);
            context.Customers.AddRange(customers);
            context.Orders.AddRange(orders);

            base.Seed(context);
        }
    }
}
