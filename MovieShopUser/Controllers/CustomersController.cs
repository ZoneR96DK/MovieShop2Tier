using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieShopDLL;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;
using MovieShopUser.Models;

namespace MovieShopUser.Controllers
{
    public class CustomersController : Controller
    {
        private string _isInfoValid;
        private string _isEmailValid;
        private IServiceGateway<Customer> _cm = DllFacade.GetCustomerServiceGateway();
        private IServiceGateway<Address> _am = DllFacade.GetAddressServiceGateway();
        private IServiceGateway<Movie> _mm = DllFacade.GetMovieServiceGateway();
        private IServiceGateway<Order> _om = DllFacade.GetOrderServiceGateway();
        
        //GET method for getting screen with email input
        //We check for id and return appropriate CheckView 
        //THere are two options - in case we have tempdata true (invalid email input)
        public ActionResult CheckEmail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _mm.Read(id.Value);
            if (movie == null)
            {
                return HttpNotFound();
            }
            if (TempData["RedirectedEmail"] != null)
            {
                _isEmailValid = "Submit a valid email.";
                ViewBag.Message = _isEmailValid;
                return View(movie);
            }
            _isEmailValid = "";
            ViewBag.Message = _isEmailValid;
            return View(movie);
        }

        //Validation for email. This could be moved and implemented inside DLL package in next versions.
        public bool IsValidEmail(string email)
        {
            try
            {
                new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //POST method for checking email, this redirect us to next section or send us back with tempdata.
        [HttpPost]
        public ActionResult CheckEmail(string email, int movieId)
        {
            if (ModelState.IsValid && IsValidEmail(email))
            {


                var customers = _cm.Read();
                var customerFound = customers.FirstOrDefault(x => x.Email == email);
                Movie movie = _mm.Read(movieId);
                var orderCheckoutView = new OrderCheckoutView()
                {
                    Customer = customerFound,
                    Movie = movie,
                    Email = email
                };
                TempData["orderCheckoutView"] = orderCheckoutView;
                return RedirectToAction("ConfirmCustomerDetails"); //new customer view

            }
            //Movie m = _mm.Read(movieId);
            TempData["RedirectedEmail"] = true;
            return RedirectToAction("CheckEmail", new {Id = movieId});

        }

        //GET method for customer input page. Added ViewBag message.
        [HttpGet]
        public ActionResult ConfirmCustomerDetails()
        {
            OrderCheckoutView orderCheckoutView = (OrderCheckoutView) TempData["orderCheckoutView"];
            _isInfoValid = "";
            ViewBag.Message = _isInfoValid;
            return View(orderCheckoutView); //new customer view
            

        }

        //POST method for Customer details page, this check for multiple validations, creates needed entities and redirect us to proper view.
        [HttpPost, ActionName("ConfirmCustomerDetails")]
        public ActionResult ConfirmCustomerDetails(Customer customer, int? customerId, int movieId, Address address)
        {
            if (ModelState.IsValid)
            {
                if (customerId != null)
                {
                    _om.Create(new Order()
                    {
                        CustomerId = customerId.Value,
                        MovieId = movieId,
                        Date = DateTime.Now
                    });
                    Address addressToUpdate = _am.Read(customerId.Value);
                    addressToUpdate = address;
                    addressToUpdate.Id = customerId.Value;
                    _am.Update(addressToUpdate);
                    Customer custmerToUpdate = _cm.Read(customerId.Value);
                    custmerToUpdate = customer;
                    custmerToUpdate.Id = customerId.Value;
                    _cm.Update(custmerToUpdate);
                    return RedirectToAction("ConfirmationView");
                }

                _cm.Create(new Customer()
                {
                    Address = address,
                    Email = customer.Email,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName
                });
                Customer orderingCustomer = _cm.Read().FirstOrDefault(x => x.Email == customer.Email);
                _om.Create(new Order()
                {
                    CustomerId = orderingCustomer.Id,
                    MovieId = movieId,
                    Date = DateTime.Now

                });
                return RedirectToAction("ConfirmationView");
                
            }
            TempData["RedirectedUserInfo"] = true;
            var customers = _cm.Read();
            var customerFound = customers.FirstOrDefault(x => x.Email == customer.Email);
            Movie movie = _mm.Read(movieId);
            var ocv= new OrderCheckoutView()
            {
                Customer = customerFound,
                Movie = movie,
                Email = customer.Email
            };
            _isInfoValid = "Invalid data.";
            ViewBag.Message = _isInfoValid;
            return View(ocv);
            
        }

        //GET method for confirmatipn page. Static page.
        [HttpGet]
        public ActionResult ConfirmationView()
        {
            
            return View();


        }
    }
}
