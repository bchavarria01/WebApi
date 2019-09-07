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
    public class PriceUpdatedLogController : BaseController
    {
        private readonly WebApiDBContext _context;

        public PriceUpdatedLogController(WebApiDBContext context)
        {
            _context = context;
        }
        //Get a list of priceupodatedlog
        [HttpGet]
        public ActionResult<List<PriceUpdatedLog>> Get()
        {
            if (_context.PriceUpdatedLogs.ToList().Count > 0)
            {
                return _context.PriceUpdatedLogs.ToList();
            }
            var error = returnObject("Logs not found", 404, 0);
            return NotFound(error);
        }
        // GET api/priceupodatedlog/5
        [HttpGet("{id}")]
        public ActionResult<PriceUpdatedLog> Get(int id)
        {
            var res = _context.PriceUpdatedLogs.Where(x => x.PriceUpdatedLogId == id).FirstOrDefault();
            if (res != null)
            {
                return res;
            }
            var error = returnObject("Log not found", 404, 0);
            return NotFound(error);
        }

        // POST api/priceupodatedlog
        [HttpPost]
        public IActionResult Post([FromBody] PriceUpdatedLog productsLog)
        {
            try
            {
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

        // PUT api/priceupodatedlog
        [HttpPut]
        public IActionResult Put([FromBody] PriceUpdatedLog productsLog)
        {
            try
            {
                PriceUpdatedLog _productsLog = _context.PriceUpdatedLogs.FirstOrDefault(x => x.PriceUpdatedLogId == productsLog.PriceUpdatedLogId);
                _productsLog.ProductId = productsLog.ProductId;
                _productsLog.CurrentPrice = productsLog.CurrentPrice;
                _productsLog.NewPrice = productsLog.NewPrice;
                _context.SaveChanges();
                var message = returnObject("log modified correctly", 200, 1);
                return Ok(message);
            }
            catch (Exception ex)
            {
                string e = ex.Message;
                var error = returnObject(e, 400, 0);
                return BadRequest(error);
            }
        }

        // DELETE api/priceupodatedlog/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            PriceUpdatedLog productsLog = _context.PriceUpdatedLogs.Find(id);
            if (productsLog == null)
            {
                var error = returnObject("Lod does not exist", 404, 0);
                return NotFound(error);
            }
            _context.PriceUpdatedLogs.Remove(productsLog);
            _context.SaveChanges();
            var message = returnObject("Log deleted correctly", 200, 1);
            return Ok(message);
        }
    }
}
