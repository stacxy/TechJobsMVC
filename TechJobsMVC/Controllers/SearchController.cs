using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Controllers;
using TechJobsMVC.Models;

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view.
        //POST: 
        [HttpPost]
      
        [Route ("/Search/Results")]
        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Job> jobs;
            if (searchTerm == null)
            {
                searchTerm = "all";
            }
         
            jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            ViewBag.title = "Jobs with " + searchType + ": " + searchTerm;

           
            ViewBag.jobs = jobs;
            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.searchType = searchType;


            return View("Index", jobs);
        }
    }
}
