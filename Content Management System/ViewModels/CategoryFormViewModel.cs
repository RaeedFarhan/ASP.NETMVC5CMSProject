using Content_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Content_Management_System.ViewModels
{
    public class CategoryFormViewModel
    {
        public IEnumerable<Language> Languages { get; set; }
        public IEnumerable<CategoryName> CategoryNames { get; set; }
        public Category Category { get; set; }
        public List<CategoryName> NewCategoryNames { get; set; }
    }
}