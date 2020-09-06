using JobListing.Filters;
using JobListing.Models;
using JobListing.Repositories;
using NinjaNye.SearchExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobListing.Controllers
{
    public class JobController : Controller
    {
        JobRepository repo = new JobRepository();
       

           // GET: Job
           [LoginFilter]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Jobs model)
        {
                model.CreatedDate = DateTime.Now;
                repo.Add(model);
            
            return View();
        }
        public ActionResult JobDetail(int Id)
        {
            var jobDetail = repo.GetById(Id);   
            return View(jobDetail);
        }
        public ActionResult JobSearch()
        {
            return View();
        }
        [HttpPost]
        public ActionResult JobSearch(string title, int categoryId,string location)
        {
            List<Jobs> searchList = new List<Jobs>();
            
            if (categoryId == 0)
            {
                var data = repo.GetByFilter(x => x.IsDelete == false);
                    searchList = data.Search(x => x.JobTitle,
                                           x => x.Location
                ).Containing(title, location).ToList();
            }
            else
            {
                var data = repo.GetByFilter(x => x.IsDelete == false && x.CategoryId == categoryId);
                    searchList = data.Search(x => x.JobTitle,
                                           x => x.Location
                ).Containing(title, location).ToList();
            }

            if (searchList.Count < 1)
            {
                ViewBag.Message = "The result you are searching for couldn't find";
            }
            return View(searchList);
        }
    }
}