using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieShopUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopUser.Models.Tests
{
    [TestClass()]
    public class CurrencyConverterTests
    {
        [TestMethod()]
        public void ConvertTestEUR()
        {
            CurrencyConverter ccr = new CurrencyConverter();
            CurrencyConverter.currency = Currency.EUR;

            Assert.AreEqual(ccr.Convert(100), 13.44);
        }

        [TestMethod()]
        public void ConvertTestUSD()
        {
            CurrencyConverter ccv = new CurrencyConverter();
            CurrencyConverter.currency = Currency.USD;

            double price = ccv.Convert(100);

            Assert.AreEqual(ccv.Convert(100), 14.38);
        }
    }
}