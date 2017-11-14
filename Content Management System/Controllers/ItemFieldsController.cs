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
    public class ItemFieldsController : Controller
    {
        private ApplicationDbContext _context;
        public ItemFieldsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: ItemFileds
        public ActionResult Index()
        {
            var itemFields = _context.ItemFields.Include(c => c.Item).ToList();

            return View(itemFields);
        }
        public ActionResult Save()
        {
            var items = _context.Items.ToList();

            ItemFieldFormViewModel viewModel = new ItemFieldFormViewModel
            {
                Items = items
            };

            return View("ItemFieldForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(ItemFieldFormViewModel viewModel)
        {
            if (viewModel.ItemField.Id == 0)
            {
                _context.ItemFields.Add(viewModel.ItemField);
            }
            else
            {
                var itemField = _context.ItemFields.Single(cf => cf.Id == viewModel.ItemField.Id);
                itemField = viewModel.ItemField;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "ItemFields");
        }
        public ActionResult Edit(int id)
        {
            var itemField = _context.ItemFields.SingleOrDefault(cf => cf.Id == id);
            if (itemField == null)
                return HttpNotFound();
            var Items = _context.Items.ToList();

            var viewModel = new ItemFieldFormViewModel
            {
                Items = Items,
                ItemField = itemField
            };
            return View("ItemFieldForm", viewModel);
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}