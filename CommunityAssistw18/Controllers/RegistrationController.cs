using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistw18.Models;

namespace CommunityAssistw18.Controllers
{
    public class RegistrationController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "FirstName, Email, Phone, PlainPassword, Apartment, Street, City, State, Zipcode")]NewPerson p)
        {
            int result = db.usp_Register(p.LastName, p.FirstName, p.Email, p.Phone, p.PlainPassword, p.Apartment, p.Street, p.City, p.State, p.Zipcode);

            if (result != -1)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}