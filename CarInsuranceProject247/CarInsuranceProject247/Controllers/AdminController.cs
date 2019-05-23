using CarInsuranceProject247.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceProject247.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            //logic to pull data from the database
            using (CarInsuranceQuoteDataEntities db = new CarInsuranceQuoteDataEntities())
            {
                var quotedatas = (from c in db.QuoteDatas
                                  select c).ToList();

            return View(quotedatas);
            }
                
        }

    }
}