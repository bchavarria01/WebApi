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
    public class PriceUpdatedLogController : Controller
    {
        private readonly WebApiDBContext _context;

        public PriceUpdatedLogController(WebApiDBContext context)
        {
            _context = context;
        }
        //Get a list of priceupodatedlog
        [HttpGet]
        public List<PriceUpdatedLog> Get()
        {
            return _context.PriceUpdatedLogs.ToList();
        }
        // GET api/priceupodatedlog/5
        [HttpGet("{id}")]
        public ActionResult<PriceUpdatedLog> Get(int id)
        {
            return _context.PriceUpdatedLogs.Where(x => x.PriceUpdatedLogId == id).FirstOrDefault();
        }

        // POST api/priceupodatedlog
        [HttpPost]
        public void Post([FromBody] PriceUpdatedLog productsLog)
        {
            try
            {
                _context.Add(productsLog);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string e = ex.Message;
            }
        }

        // PUT api/priceupodatedlog
        [HttpPut]
        public void Put([FromBody] PriceUpdatedLog productsLog)
        {
            try
            {
                PriceUpdatedLog _productsLog = _context.PriceUpdatedLogs.FirstOrDefault(x => x.PriceUpdatedLogId == productsLog.PriceUpdatedLogId);
                _productsLog.ProductId = productsLog.ProductId;
                _productsLog.CurrentPrice = productsLog.CurrentPrice;
                _productsLog.NewPrice = productsLog.NewPrice;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string e = ex.Message;
            }
        }

        // DELETE api/priceupodatedlog/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            PriceUpdatedLog productsLog = _context.PriceUpdatedLogs.Find(id);
            if (productsLog == null)
            {
                return;
            }
            _context.PriceUpdatedLogs.Remove(productsLog);
            _context.SaveChanges();
        }
    }
}
