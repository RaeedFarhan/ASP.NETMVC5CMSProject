using Content_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Content_Management_System.ViewModels
{
    public class MenuFormViewModel
    {
        public IEnumerable<Language> Languages { get; set; }
        public IEnumerable<MenuName> MenuNames { get; set; }
        public Menu Menu { get; set; }
        public List<MenuName> NewMenuNames { get; set; }
    }
}