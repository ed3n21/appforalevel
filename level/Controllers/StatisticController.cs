using AutoMapper;
using BL.ModelsBL;
using BL.Services;
using level.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace level.Controllers
{
    public class StatisticController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public StatisticController(ITransactionService transactionService, ICategoryService categoryService, IMapper mapper)
        {
            _transactionService = transactionService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // GET: Statistic
        public ActionResult Index()
        {
            return View();
        }

        // GET: Statistic/CategorySuggestion?query=video
        [HttpGet]
        public JsonResult Suggestion(string query)
        {
            var filteredSuggestions = _mapper.Map<IEnumerable<SuggestionModel>>(_categoryService.Get())
                .Where(src => src.value.ToLower().Contains(query.ToLower()));

            return Json(new { suggestions = filteredSuggestions }, JsonRequestBehavior.AllowGet);
        }

        // GET: Statistic/Chart
        [HttpGet]
        public JsonResult Chart(int categoryId)
        {
            // TODO: make period of time and counting mode(day/month/...) depends on received json data
            // retreiving transaction values during last 7 days in order [day7....day1]
            decimal[] spends = new decimal[7];
            for (int i = 0; i < 7; i++)
            {
                spends[i] = _transactionService.Get().Where(t => t.CategoryId == categoryId).Where(t => t.Date.Day == DateTime.Now.Day - 6 + i).Select(t => t.Value).Sum();
            }

            return Json(spends, JsonRequestBehavior.AllowGet);
        }

        // GET: Statistic/FooTest
        public decimal FooTest()
        {
            decimal[] spends = new decimal[7];
            for (int i = 0; i < 7; i++)
            {
                spends[i] = _transactionService.Get().Where(t => t.CategoryId == 1).Where(t => t.Date.Day == DateTime.Now.Day - 6 + i).Select(t => t.Value).Sum();
            }
            return spends[6];
        }
    }
}