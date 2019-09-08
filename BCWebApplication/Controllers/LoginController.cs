using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BCWebApi.Models;
using BCWebApplication.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BCWebApplication.Controllers
{
    public class LoginController : Controller
    {
        const string SessionName = "_Name";
        const string SessionType = "_UserType";
        static List<User> lstUsers = new List<User>();
        WebApi _api = new WebApi();
        public LoginController()
        {
            _ = GetUsersAsync();
        }
        private async Task<List<User>> GetUsersAsync()
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/user");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                lstUsers = JsonConvert.DeserializeObject<List<User>>(result);
            }
            return lstUsers;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString(SessionName) != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create(User modelo)
        {
            _ = GetUsersAsync();
            try
            {
                if (ModelState.IsValid)
                {
                    var user = lstUsers.FirstOrDefault(x => x.UserName == modelo.UserName && x.UserPassword == modelo.UserPassword);
                    if (user == null)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                    HttpContext.Session.SetString(SessionName, user.UserName);
                    HttpContext.Session.SetString(SessionType, user.UserTypeId.ToString());
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {

                ViewData["mensaje"] = ex.Message;
                return RedirectToAction("Index", "Login");
            }

        }
        public ActionResult CloseSession()
        {
            //HttpContext.Session.SetString(SessionName, "");
            //HttpContext.Session.SetString(SessionType, "");
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
