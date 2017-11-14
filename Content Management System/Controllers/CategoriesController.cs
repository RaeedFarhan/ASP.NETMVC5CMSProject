using Content_Management_System.Models;
using Content_Management_System.ViewModels;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Content_Management_System.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _context;
        public CategoriesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Categories
        public ActionResult Index()
        {
            var categories = _context.CategoryNames.Include(c => c.Category).Include(l => l.Language).ToList();

            return View(categories);
        }
        public ActionResult Save()
        {
            var languages = _context.Languages.ToList();
            var categoryNames = _context.CategoryNames.ToList();
            List<CategoryName> newCategoryNames = new List<CategoryName>();
            foreach (var lang in languages)
            {
                newCategoryNames.Add(new CategoryName { LanguageId = lang.Id });
            }
            CategoryFormViewModel viewModel = new CategoryFormViewModel
            {
                Languages = languages,
                CategoryNames = categoryNames,
                NewCategoryNames = newCategoryNames
            };

            return View("CategoryForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(CategoryFormViewModel viewModel)
        {
            if (viewModel.Category.Id == 0)
            {
                _context.Categories.Add(viewModel.Category);
                _context.SaveChanges();
                foreach (var categoryName in viewModel.NewCategoryNames)
                {
                    categoryName.CategoryId = viewModel.Category.Id;
                    _context.CategoryNames.Add(categoryName);
                }
            }
            else
            {
                var category = _context.Categories.Single(c => c.Id == viewModel.Category.Id);
                category = viewModel.Category;
                var categoryNameInDb = _context.CategoryNames.Where(cn => cn.CategoryId == viewModel.Category.Id).ToList();
                for (int i = 0; i < categoryNameInDb.Count; i++)
                {
                    categoryNameInDb[i].Name = viewModel.NewCategoryNames[i].Name;
                }
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Categories");
        }
        public ActionResult Edit(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);
            List<CategoryName> newCategoryNames = _context.CategoryNames.Where(ncn => ncn.CategoryId == id).ToList();
            if (category == null || newCategoryNames == null)
                return HttpNotFound();
            var languages = _context.Languages.ToList();
            var categoryNames = _context.CategoryNames.ToList();
            
            var viewModel = new CategoryFormViewModel
            {
                Languages = languages,
                CategoryNames = categoryNames,
                Category = category,
                NewCategoryNames = newCategoryNames
            };
            return View("CategoryForm", viewModel);
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}