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
    [Route("api/[controller]")]
    public class ProductsLogController : Controller
    {
        private readonly WebApiDBContext _context;

        public ProductsLogController(WebApiDBContext context)
        {
            _context = context;
        }
        //Get a list of productsLog
        [HttpGet]
        public List<ProductsLog> Get()
        {
            return _context.ProductsLogs.ToList();
        }
        // GET api/productslog/5
        [HttpGet("{id}")]
        public ActionResult<ProductsLog> Get(int id)
        {
            return _context.ProductsLogs.Where(x => x.ProductsLogId == id).FirstOrDefault();
        }

        // POST api/productslog
        [HttpPost]
        public void Post([FromBody] ProductsLog productsLog)
        {
            try
            {
                productsLog.BuyingDate = DateTime.Now;
                _context.Add(productsLog);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string e = ex.Message;
            }
        }

        // PUT api/productslog
        [HttpPut]
        public void Put([FromBody] ProductsLog productsLog)
        {
            try
            {
                ProductsLog _productsLog = _context.ProductsLogs.FirstOrDefault(x => x.ProductsLogId == productsLog.ProductsLogId);
                _productsLog.UserId = productsLog.UserId;
                _productsLog.ProductId = productsLog.ProductId;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string e = ex.Message;
            }
        }

        // DELETE api/productslog/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ProductsLog productsLog = _context.ProductsLogs.Find(id);
            if (productsLog == null)
            {
                return;
            }
            _context.ProductsLogs.Remove(productsLog);
            _context.SaveChanges();
        }
    }
}
