using Content_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Content_Management_System.ViewModels
{
    public class ItemFormViewModel
    {
        public IEnumerable<Language> Languages { get; set; }
        public IEnumerable<MenuName> MenuNames { get; set; }
        public IEnumerable<CategoryName> CategoryNames { get; set; }
        public List<CategoryField> CategoryFields { get; set; }
        public Item Item { get; set; }
    }
}