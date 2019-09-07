using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BCWebAdmin.Helper;
using BCWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BCWebAdmin.Controllers
{
    public class ProductController : Controller
    {
        // GET: /<controller>/
        WebApi _api = new WebApi();
        public async Task<IActionResult> Index()
        {
            List<Product> lstProducts = new List<Product>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/product");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                lstProducts = JsonConvert.DeserializeObject<List<Product>>(result);
            }
            return View(lstProducts);
        }
    }
}
