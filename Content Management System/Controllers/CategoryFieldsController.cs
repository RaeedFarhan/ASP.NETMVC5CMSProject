using Content_Management_System.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Content_Management_System.ViewModels;

namespace Content_Management_System.Controllers
{
    public class CategoryFieldsController : Controller
    {
        private ApplicationDbContext _context;
        public CategoryFieldsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: CategoryFields
        public ActionResult Index()
        {
            var categoryFields = _context.CategoryFields.Include(c => c.Category).ToList();

            return View(categoryFields);
        }
        public ActionResult Save()
        {
            var categoryNames = _context.CategoryNames.ToList();
            
            CategoryFieldFormViewModel viewModel = new CategoryFieldFormViewModel
            {
                CategoryNames = categoryNames
            };

            return View("CategoryFieldForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(CategoryFieldFormViewModel viewModel)
        {
            if (viewModel.CategoryField.Id == 0)
            {
                _context.CategoryFields.Add(viewModel.CategoryField);
            }
            else
            {
                var categoryField = _context.CategoryFields.Single(cf => cf.Id == viewModel.CategoryField.Id);
                categoryField = viewModel.CategoryField;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "CategoryFields");
        }
        public ActionResult Edit(int id)
        {
            var categoryField = _context.CategoryFields.SingleOrDefault(cf => cf.Id == id);
            if (categoryField == null)
                return HttpNotFound();
            var categoryNames = _context.CategoryNames.ToList();

            var viewModel = new CategoryFieldFormViewModel
            {
                CategoryNames = categoryNames,
                CategoryField = categoryField
            };
            return View("CategoryFieldForm", viewModel);
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}