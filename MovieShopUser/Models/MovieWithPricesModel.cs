using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieShopDLL.Entities;

namespace MovieShopUser.Models
{
    public class MovieWithPricesModel
    {
        public CurrencyConverter CurrencyConverter { get; set; }
        public string CurrencyToChange { get; set; }
        public Movie Movie { get; set; }
        public double valueOfCurrency { get; set; }
    }
}