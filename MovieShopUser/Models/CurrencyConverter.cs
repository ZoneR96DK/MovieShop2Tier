using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShopUser.Models
{

    public enum Currency { DKK, USD, EUR };

    public class CurrencyConverter
    {
        
        public readonly double USD = 0.143797;
        public readonly double EUR = 0.134377161;

        public static Currency currency;

        /*public void Setcurrency(Currency money)
        {
            currency = money;
        }*/

        public double Convert(double price)
        {
            if (currency == Currency.USD)
            {
                double USDprice = price * USD;
                
                return Math.Round(USDprice, 2); ;
            }

            if (currency == Currency.EUR)
            {
                double EURprice = price * EUR;
                
                return Math.Round(EURprice, 2);
            }
            else
                return price;
        }
    }    
}