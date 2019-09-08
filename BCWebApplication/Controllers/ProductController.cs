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

        public ActionResult Create()
        {
            var product = new Product();
            return PartialView(product);
        }

        public async Task<IActionResult> Edit(string id)
        {
            Product product = new Product();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/product/" + id);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<Product>(result);
            }
            return PartialView(product);
        }

        [HttpPost]
        public ActionResult Create(Product modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewData["mensaje"] = "La cuenta ha sido agregada exitosamente";
                    return PartialView("_AlertSuccess");
                }
                else
                {
                    ViewData["mensaje"] = "Error en la inserción de datos";
                    return PartialView("_AlertFailure");
                }
            }
            catch (Exception ex)
            {

                ViewData["mensaje"] = "Error en la inserción de datos";
                return PartialView("_AlertFailure");
            }

        }

        [HttpPost]
        public ActionResult Edit(Product modelo)
        {
            return PartialView(modelo);
        }
    }
}