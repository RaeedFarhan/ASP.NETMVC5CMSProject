using Content_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Content_Management_System.ViewModels
{
    public class ItemFieldFormViewModel
    {
        public IEnumerable<Item> Items { get; set; }
        public ItemField ItemField { get; set; }
    }
}