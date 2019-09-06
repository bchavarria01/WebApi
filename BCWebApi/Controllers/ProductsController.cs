using System;
using System.Collections.Generic;
using System.Linq;
using BCWebApi.Context;
using BCWebApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace BCWebApi.Controllers
{
    [Route("api/product")]
    public class ProductsController : Controller
    {
        private readonly WebApiDBContext _context;

        public ProductsController(WebApiDBContext context)
        {
            _context = context;
        }
        //Get a list of products
        [HttpGet]
        public List<Product> Get()
        {
            return _context.Products.ToList();
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            try
            {
                _context.Add(product);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string e = ex.Message;
            }
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody] Product product)
        {
            try
            {
                Product _product = _context.Products.FirstOrDefault(x => x.ProductId == product.ProductId);
                _product.Name = product.Name;
                _product.StockQuantity = product.StockQuantity;
                _product.Price = product.Price;
                _context.Products.Update(_product);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string e = ex.Message;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Product product = _context.Products.Find(id);
            if (product == null)
            {
                return;
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
