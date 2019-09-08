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
            return View(product);
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
            return View(product);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Product modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewData["mensaje"] = "La cuenta ha sido agregada exitosamente";
                    Product product = new Product();
                    HttpClient client = _api.Initial();
                    //HttpResponseMessage res = await client.GetAsync("api/product/" + id);
                    var model = JsonConvert.SerializeObject(modelo);
                    HttpContent content = new StringContent(model, Encoding.UTF8, "application/json");
                    var url = new Uri(client.BaseAddress + "api/product");
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
        public ActionResult Edit(Product modelo)
        {
            if (ModelState.IsValid)
            {
                ViewData["mensaje"] = "Product modified correctly";
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync("api/product/" + id);
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}