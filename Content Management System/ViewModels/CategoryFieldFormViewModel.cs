using Content_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Content_Management_System.ViewModels
{
    public class CategoryFieldFormViewModel
    {
        public IEnumerable<CategoryName> CategoryNames { get; set; }
        public CategoryField CategoryField { get; set; }
    }
}