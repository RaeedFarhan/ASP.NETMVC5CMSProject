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
    public class MenusController : Controller
    {
        private ApplicationDbContext _context;
        public MenusController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Menus
        public ActionResult Index()
        {
            var menus = _context.MenuNames.Include(m => m.Menu).Include(l => l.Language).ToList();
            
            return View(menus); 
        }
        public ActionResult Save()
        {
            var languages = _context.Languages.ToList();
            var menuNames = _context.MenuNames.ToList();
            List<MenuName> newMenuNames = new List<MenuName>();
            foreach (var lang in languages)
            {
                newMenuNames.Add( new MenuName { LanguageId = lang.Id });
            }
            MenuFormViewModel viewModel = new MenuFormViewModel
            {
                Languages = languages,
                MenuNames = menuNames,
                NewMenuNames = newMenuNames
            };
            
            return View("MenuForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(MenuFormViewModel viewModel)
        {
            if(viewModel.Menu.Id == 0)
            {
                _context.Menus.Add(viewModel.Menu);
                _context.SaveChanges();
                foreach (var menuName in viewModel.NewMenuNames)
                {
                    menuName.MenuId = viewModel.Menu.Id;
                    _context.MenuNames.Add(menuName);
                }
            }
            else
            {
                var menu = _context.Menus.Single(m => m.Id == viewModel.Menu.Id);
                menu = viewModel.Menu;
                var menuNameInDb = _context.MenuNames.Where(mn => mn.MenuId == viewModel.Menu.Id).ToList();
                for (int i = 0; i < menuNameInDb.Count; i++)
                {
                    menuNameInDb[i].Name = viewModel.NewMenuNames[i].Name;
                }
                menu.ParentMenuId = viewModel.Menu.ParentMenuId;
                menu.Type = viewModel.Menu.Type;
                menu.IsActive = viewModel.Menu.IsActive;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Menus");
        }
        public ActionResult Edit(int id)
        {
            var menu = _context.Menus.SingleOrDefault(m => m.Id == id);
            List<MenuName> newMenuNames = _context.MenuNames.Where(nmn => nmn.MenuId == id).ToList();
            if (menu == null || newMenuNames == null)
                return HttpNotFound();
            var languages = _context.Languages.ToList();
            var menuNames = _context.MenuNames.ToList();

            var viewModel = new MenuFormViewModel
            {
                Languages = languages,
                MenuNames = menuNames,
                Menu = menu,
                NewMenuNames = newMenuNames
            };
            return View("MenuForm", viewModel);
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}