using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistw18.Models;

namespace CommunityAssistw18.Controllers
{
    public class DonationController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: Donation
        public ActionResult Index()
        {
            if (Session["reviewerKey"] == null)
            {
                MessageClass m = new MessageClass();
                m.MessageText = "Must be logged in to make a donation";
                return RedirectToAction("Result", m);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index([Bind(Include = "DonationKey,PersonKey,DonationDate,DonationAmount, ConationConformationCode")]Donation d)
        {
            d.DonationDate = DateTime.Now;
            d.PersonKey = (int)Session["reviewerKey"];
            d.DonationConfirmationCode = Guid.NewGuid();
            db.Donations.Add(d);
            db.SaveChanges();

            MessageClass m = new MessageClass();
            m.MessageText = "Thank you for your generous donation!";

            return View("Result", m);
        }

        public ActionResult Result(MessageClass m)
        {
            return View(m);
        }

    }
}