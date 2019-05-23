using CarInsuranceProject247.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceProject247.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QuoteSummary()
        {
            ViewBag.Message = "Quote Summary";

            return View();
        }

        public ActionResult RequestQuote()
        {
            ViewBag.Message = "Enter information below to request a quote.";

            return View();
        }

        [HttpPost]
        public ActionResult UserInput(string firstName, string lastName, string emailAddress,
                                      DateTime dateOfBirth, int carYear, string carMake, string carModel,
                                      string dUI, int ticket, string coverageType)
        {
            //Utilizing entity framework:
            //create an instance of the database to control open/close
            using (CarInsuranceQuoteDataEntities db = new CarInsuranceQuoteDataEntities())
            {
                //create an instance of database table QuoteData
                var userinput = new QuoteData();
                //Assign user input value to the database parameters
                userinput.FirstName = firstName;
                userinput.LastName = lastName;
                userinput.EmailAddress = emailAddress;
                userinput.DateOfBirth = dateOfBirth;
                userinput.CarYear = carYear;
                userinput.CarMake = carMake;
                userinput.CarModel = carModel;
                userinput.DUI = dUI;
                userinput.Ticket = ticket;
                userinput.CoverageType = coverageType;
                //calcaulate quote based on usre input
                int quote = 50;
                //Perfrom logic checks on Age
                int age = DateTime.Now.Year - dateOfBirth.Year;
                if (age < 25 & age > 17)
                {
                    quote = quote + 25;
                }
                else if (age < 18)
                {
                    quote = quote + 100;
                }
                else if (age > 100)
                {
                    quote = quote + 25;
                }

                //Perform logic check on carYear
                if (carYear < 2000 || carYear > 2015)
                {
                    quote = quote + 25;
                }
                //Perform logic checks on carMake and model
                if (carMake.ToLower() =="porsche")
                {
                    quote = quote + 25;
                }

                if (carMake.ToLower() == "porsche" & carModel.ToLower() == "911 carrera")
                {
                    quote = quote + 25;
                }

                //Perform logic check on speeding tickets
                if (ticket >0)
                {
                    quote = quote + ticket*10;
                }

                //Perform logic check on DUI
                if (dUI.ToLower() == "yes" || dUI.ToLower() == "once" || dUI.ToLower() == "yeah" || dUI.ToLower() == "y")
                {
                    quote = Convert.ToInt32(Convert.ToDouble(quote) * 1.25);
                }
                //Perform logic check on coverage type
                if (coverageType.ToLower() == "full coverage")
                {
                    quote = Convert.ToInt32(Convert.ToDouble(quote) * 1.50);
                }

                userinput.Quote = quote;
                //save quote in viewbag to access in view
                ViewBag.Quote = userinput.Quote;

                //add instance of user input to the database db and table QuoteData
                db.QuoteDatas.Add(userinput);
                db.SaveChanges();
            }

            return View("QuoteSummary");
        }

    }
}