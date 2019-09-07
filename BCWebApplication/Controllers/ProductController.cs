using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BCWebApi.Models;
using BCWebApplication.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BCWebApplication.Controllers
{
    public class ProductController : Controller
    {
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