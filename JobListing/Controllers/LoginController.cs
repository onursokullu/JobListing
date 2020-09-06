using JobListing.Models;
using JobListing.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobListing.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Users model )
        {
            UserRepository repo = new UserRepository();
            var user = repo.Login(model.Email, model.Password);
            if (user != null)
            {   
                Session["LoginUser"] = user;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Message"] = new TempDataDictionary { { "class", "alert-danger" }, { "Msg", "Email or password is wrong!" } };
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Users model)
        {
            using(UserRepository repo = new UserRepository())
            {
                model.CreatedDate = DateTime.Now;
                model.IsActive = true;
                var result = repo.Add(model);
                return View();
            }
           
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}