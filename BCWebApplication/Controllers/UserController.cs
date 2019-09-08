using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BCWebApi.Models;
using BCWebApplication.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BCWebApplication.Controllers
{
    public class UserController : Controller
    {
        // GET: /<controller>/
        WebApi _api = new WebApi();
        public async Task<IActionResult> Index()
        {
            List<User> lstUsers = new List<User>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/user");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                lstUsers = JsonConvert.DeserializeObject<List<User>>(result);
            }
            return View(lstUsers);
        }

        public async Task<ActionResult> Create()
        {
            var user = new User();
            List<UserType> lstUsers = new List<UserType>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/usertype");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                lstUsers = JsonConvert.DeserializeObject<List<UserType>>(result);
            }
            ViewData["lstUserTypes"] = lstUsers;
            return View(user);
        }

        public async Task<IActionResult> Edit(string id)
        {
            User user = new User();
            List<UserType> lstUsers = new List<UserType>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/user/" + id);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<User>(result);

                HttpResponseMessage res1 = await client.GetAsync("api/usertype");
                if (res.IsSuccessStatusCode)
                {
                    var result1 = res1.Content.ReadAsStringAsync().Result;
                    lstUsers = JsonConvert.DeserializeObject<List<UserType>>(result1);
                }
            }
            ViewData["lstUserTypes"] = lstUsers;
            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> Create(User modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewData["mensaje"] = "La cuenta ha sido agregada exitosamente";
                    User user = new User();
                    HttpClient client = _api.Initial();
                    //HttpResponseMessage res = await client.GetAsync("api/user/" + id);
                    var model = JsonConvert.SerializeObject(modelo);
                    HttpContent content = new StringContent(model, Encoding.UTF8, "application/json");
                    var url = new Uri(client.BaseAddress + "api/user");
                    HttpResponseMessage res = await client.PostAsync(url, content);
                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View(modelo);
            }
            catch (Exception ex)
            {

                ViewData["mensaje"] = ex.Message;
                return View(modelo);
            }

        }

        [HttpPost]
        public async Task<ActionResult> Edit(User modelo)
        {
            if (ModelState.IsValid)
            {
                ViewData["mensaje"] = "";
                Product product = new Product();
                HttpClient client = _api.Initial();
                //HttpResponseMessage res = await client.GetAsync("api/product/" + id);
                var model = JsonConvert.SerializeObject(modelo);
                HttpContent content = new StringContent(model, Encoding.UTF8, "application/json");
                var url = new Uri(client.BaseAddress + "api/user");
                HttpResponseMessage res = await client.PutAsync(url, content);
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(modelo);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync("api/user/" + id);
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
