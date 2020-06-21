using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebLabs.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["T"] = "Лабораторная работа №2";
            ViewData["L"] = new SelectList(_list, "ListItemValue", "ListItemText");
            return View();
        }
        public class ListDemo
        {
            public int ListItemValue { get; set; }
            public string ListItemText { get; set; }
        }
        private List<ListDemo> _list;
        public HomeController()
        {
            _list = new List<ListDemo>
            {
                new ListDemo{ ListItemValue=1, ListItemText="Item 1"},
                new ListDemo{ ListItemValue=2, ListItemText="Item 2"},
                new ListDemo{ ListItemValue=3, ListItemText="Item 3"}
            };
        }
    }
}