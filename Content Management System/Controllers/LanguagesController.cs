using Content_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Content_Management_System.Controllers
{
    public class LanguagesController : Controller
    {
        private ApplicationDbContext _context;
        public LanguagesController()
        {
            _context = new  ApplicationDbContext();
        }
        // GET: Languages
        public ActionResult Index()
        {
            var langs = _context.Languages.ToList();

            return View(langs);
        }
        public ActionResult Save()
        {
            return View("LanguageForm");
        }
        [HttpPost]
        public ActionResult Save(Language language)
        {
            if(language.Id == 0)
                _context.Languages.Add(language);
            else
            {
                var langInDb = _context.Languages.Single(l => l.Id == language.Id);
                langInDb.Name = language.Name;
                langInDb.IsActive = language.IsActive;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Languages");
        }
        public ActionResult Delete(int id)
        {
            Language langInDb = _context.Languages.Find(id);
            langInDb.IsActive = false;

            _context.SaveChanges();
            return RedirectToAction("Index", "Languages");
        }
        public ActionResult Edit(int id)
        {
            var lang = _context.Languages.SingleOrDefault(l => l.Id == id);

            if (lang == null)
                return HttpNotFound();
            return View("LanguageForm", lang);
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}