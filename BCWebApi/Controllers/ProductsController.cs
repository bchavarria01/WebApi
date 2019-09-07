using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCWebApi.Context;
using BCWebApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace BCWebApi.Controllers
{
    [Route("api/product")]
    public class ProductsController : BaseController
    {
        private readonly WebApiDBContext _context;

        public ProductsController(WebApiDBContext context)
        {
            _context = context;
        }
        //Get a list of products
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return _context.Products.ToList();
        }
        // GET api/product/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            if (res != null)
            {
                return res;
            }
            var error = returnObject("Product not found", 404, 0);
            return NotFound(error);
        }

        // POST api/product
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _context.Add(product);
                _context.SaveChanges();
                var message = returnObject("Product added correctly", 200, 1);
                return Ok(message);
            }
            catch (Exception ex)
            {
                string e = ex.Message;
                var error = returnObject(e, 400, 0);
                return BadRequest(error);
            }
        }

        // PUT api/product/5
        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            try
            {
                Product _product = _context.Products.FirstOrDefault(x => x.ProductId == product.ProductId);
                _product.Name = product.Name;
                _product.StockQuantity = product.StockQuantity;
                _product.Price = product.Price;
                _context.Products.Update(_product);
                _context.SaveChanges();
                var message = returnObject("Product modified correctly", 200, 1);
                return Ok(message);
            }
            catch (Exception ex)
            {
                string e = ex.Message;
                var error = returnObject(e, 400, 0);
                return BadRequest(error);
            }
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product product = _context.Products.Find(id);
            if (product == null)
            {
                var error = returnObject("Not found any product with this Id", 404, 0);
                return NotFound(error);
            }
            try
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                var message = returnObject("Product deleted correctly", 200, 1);
                return Ok(message);
            }
            catch (Exception ex)
            {
                string e = ex.Message;
                var error = returnObject(e, 400, 0);
                return BadRequest(error);
            }
        }
    }
}
