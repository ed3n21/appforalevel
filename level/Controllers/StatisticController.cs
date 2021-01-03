using level.Filters;
using level.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace level.Controllers
{
    [MyAuthorize]
    [Exception]
    public class StatisticController : Controller
    {
        // GET: Statistic
     
        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Http.HttpGet]
        public JsonResult AutoCompleteSuggestion(string query)
        {
            //filteredSuggestions =  serviceCategory.GetAll().Where(x=>x.Name.contains(query)); 

            var filteredSuggestions = new List<AutocompleteModel>{
                new AutocompleteModel { data = "aa", value = "Andorra" },
                new AutocompleteModel { data = "zz", value = "Zimbabwe" }
            };

            var result = new JsonResult();
            result.Data = new { suggestions = filteredSuggestions };

            return Json(new { suggestions = filteredSuggestions }, JsonRequestBehavior.AllowGet);
        }
    }
}