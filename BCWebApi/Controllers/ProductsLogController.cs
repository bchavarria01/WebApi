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
    public class ProductsLogController : BaseController
    {
        private readonly WebApiDBContext _context;

        public ProductsLogController(WebApiDBContext context)
        {
            _context = context;
        }
        //Get a list of productsLog
        [HttpGet]
        public ActionResult<List<ProductsLog>> Get()
        {
            if (_context.ProductsLogs.ToList().Count > 0)
            {
                return _context.ProductsLogs.ToList();
            }
            var error = returnObject("Logs not found", 404, 0);
            return NotFound(error);
        }
        // GET api/productslog/5
        [HttpGet("{id}")]
        public ActionResult<ProductsLog> Get(int id)
        {
            var res = _context.ProductsLogs.Where(x => x.ProductsLogId == id).FirstOrDefault();
            if (res != null)
            {
                return res;
            }
            var error = returnObject("Log not found", 404, 0);
            return NotFound(error);
        }

        // POST api/productslog
        [HttpPost]
        public IActionResult Post([FromBody] ProductsLog productsLog)
        {
            try
            {
                productsLog.BuyingDate = DateTime.Now;
                _context.Add(productsLog);
                _context.SaveChanges();
                var message = returnObject("Log added correctly", 200, 1);
                return Ok(message);
            }
            catch (Exception ex)
            {
                string e = ex.Message;
                var error = returnObject(e, 400, 0);
                return BadRequest(error);
            }
        }

        // PUT api/productslog
        [HttpPut]
        public IActionResult Put([FromBody] ProductsLog productsLog)
        {
            try
            {
                ProductsLog _productsLog = _context.ProductsLogs.FirstOrDefault(x => x.ProductsLogId == productsLog.ProductsLogId);
                _productsLog.UserId = productsLog.UserId;
                _productsLog.ProductId = productsLog.ProductId;
                _context.SaveChanges();
                var message = returnObject("Log modified correctly", 200, 1);
                return Ok(message);
            }
            catch (Exception ex)
            {
                string e = ex.Message;
                var error = returnObject(e, 400, 0);
                return BadRequest(error);
            }
        }

        // DELETE api/productslog/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ProductsLog productsLog = _context.ProductsLogs.Find(id);
            if (productsLog == null)
            {
                var error = returnObject("Log not found", 404, 0);
                return NotFound(error);
            }
            _context.ProductsLogs.Remove(productsLog);
            _context.SaveChanges();
            var message = returnObject("Log deleted correctly", 200, 1);
            return Ok(message);
        }
    }
}
