using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistw18.Models;

namespace CommunityAssistw18.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index([Bind(Include = "Email, Password")]LoginClass lc)
        {
            CommunityAssist2017Entities db = new CommunityAssist2017Entities();
            int loginResult = db.usp_Login(lc.Email, lc.Password);
            if (loginResult != -1)
            {
                var uid = (from r in db.People
                           where r.PersonEmail.Equals(lc.Email)
                           select r.PersonKey).FirstOrDefault();
                int rKey = (int)uid;
                Session["reviewerKey"] = rKey;

                MessageClass msg = new MessageClass();
                msg.MessageText = "Thank You! You are now logged in as '" + lc.Email + "'."; 
                return RedirectToAction("Result", msg);
            }
            MessageClass message = new MessageClass();
            message.MessageText = "Invalid Login";
            return View("Result", message);
        }
        public ActionResult Result(MessageClass m)
        {
            return View(m);
        }

    }
}