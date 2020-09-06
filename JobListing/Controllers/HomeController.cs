using JobListing.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobListing.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (JobRepository repo = new JobRepository())
            {
                var jobList = repo.GetAll().ToList();
                return View(jobList);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}