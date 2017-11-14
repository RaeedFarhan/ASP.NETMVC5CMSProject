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
    public class ItemsController : Controller
    {
        private ApplicationDbContext _context;
        public ItemsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Items
        public ActionResult Index()
        {
            var items = _context.Items.Include(m => m.Menu).Include(c => c.Category).Include(l => l.Language).ToList();

            return View(items);
        }
        public ActionResult Save()
        {
            var languages = _context.Languages.ToList();
            var menuNames = _context.MenuNames.ToList();
            var categoryNames = _context.CategoryNames.ToList();

            ItemFormViewModel viewModel = new ItemFormViewModel
            {
                Languages = languages,
                MenuNames = menuNames,
                CategoryNames = categoryNames,
            };

            return View("ItemForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(ItemFormViewModel viewModel)
        {
            if (viewModel.Item.Id == 0)
            {
                _context.Items.Add(viewModel.Item);
            }
            else
            {
                var item = _context.Items.Single(i => i.Id == viewModel.Item.Id);
                item = viewModel.Item;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Items");
        }
        public ActionResult Edit(int id)
        {
            var item = _context.Items.SingleOrDefault(i => i.Id == id);
            if (item == null)
                return HttpNotFound();
            var languages = _context.Languages.ToList();
            var menuNames = _context.MenuNames.ToList();
            var categoryNames = _context.CategoryNames.ToList();
            ItemFormViewModel viewModel = new ItemFormViewModel
            {
                Languages = languages,
                MenuNames = menuNames,
                CategoryNames = categoryNames,
                Item = item
            };

            return View("ItemForm", viewModel);
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}