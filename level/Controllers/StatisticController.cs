using AutoMapper;
using BL.ModelsBL;
using BL.Services;
using level.ExtensionMethods;
using level.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static level.ExtensionMethods.StatisticExtensions;

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
            decimal[] spends = _transactionService.Get().GetStatistic(StatisticDateMode.Days, categoryId);

            return Json(spends, JsonRequestBehavior.AllowGet);
        }
    }
}