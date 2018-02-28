using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistw18.Models;

namespace CommunityAssistw18.Controllers
{
    public class NewGrantController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: NewGrant
        public ActionResult Index()
        {
            if (Session["reviewerKey"] == null)
            {
                MessageClass m = new MessageClass();
                m.MessageText = "You must be logged in to add a review.";
                return RedirectToAction("Result", m);
            }
            ViewBag.GrantType = new SelectList(db.GrantTypes, "GrantTypeKey, GrantTypeName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Type, Reason, Amount")] NewGrant ng)
        {
            GrantApplication g = new GrantApplication();
            
            g.GrantApplicationReason = ng.Reason;
            g.GrantApplicationRequestAmount = ng.Amount;
            g.GrantAppicationDate = DateTime.Now;

            db.GrantApplications.Add(g);
            db.SaveChanges();

            MessageClass m = new MessageClass();
            m.MessageText = "Thank you, the book has been added";

            return View("Result", m);

        }

        public ActionResult Result(MessageClass m)
        {
            return View(m);
        }
    }
}