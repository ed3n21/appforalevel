using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BL.ModelsBL;
using BL.Services;
using Level.Models;

namespace Level.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _service;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public TransactionController(ITransactionService service, IMapper mapper, ICategoryService categoryService)
        {
            _service = service;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        // GET: Transaction
        public ActionResult Index()
        {
            var transactions = _mapper.Map<IEnumerable<TransactionBL>, IEnumerable<TransactionModel>>(_service.Get("Category"));

            return View(transactions);
        }

        // GET: Transaction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionModel transaction = _mapper.Map<TransactionBL, TransactionModel>(_service.Get(id.Value));
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: Transaction/Create
        public ActionResult Create()
        {
            SelectList categories = new SelectList(_categoryService.Get(), "Id", "Title");
            ViewBag.Categories = categories;

            return View();
        }

        // POST: Transaction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionModel transaction)
        {
            if (ModelState.IsValid)
            {
                _service.Create(_mapper.Map<TransactionBL>(transaction));
                return RedirectToAction("Index");
            }

            ViewBag.categories = new SelectList(_categoryService.Get(), "Id", "Title");
            return View(transaction);
        }

        // GET: Transaction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionModel transaction = _mapper.Map<TransactionBL, TransactionModel>(_service.Get((int)id));
            if (transaction == null)
            {
                return HttpNotFound();
            }

            SelectList categories = new SelectList(_categoryService.Get(), "Id", "Title");
            ViewBag.Categories = categories;

            return View(transaction);
        }

        // POST: Transaction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TransactionModel transaction)
        {
            if (ModelState.IsValid)
            {
                _service.Update(_mapper.Map<TransactionModel, TransactionBL>(transaction));
                return RedirectToAction("Index");
            }
            ViewBag.categories = new SelectList(_categoryService.Get(), "Id", "Title");
            return View(transaction);
        }

        // GET: Transaction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionModel transaction = _mapper.Map<TransactionBL, TransactionModel>(_service.Get((int)id));
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
