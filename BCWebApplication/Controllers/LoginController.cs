using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BCWebApplication.Controllers
{
    public class LoginController : Controller
    {
        const string SessionName = "_Name";
        // GET: /<controller>/
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString(SessionName) != null)
            {
                return RedirectToAction("Home/Index");
            }
            return View();
        }
    }
}
