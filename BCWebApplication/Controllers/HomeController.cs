using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BCWebApplication.Models;
using Microsoft.AspNetCore.Http;

namespace BCWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("_Name") != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
