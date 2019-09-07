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
    public class UserTypeController : BaseController
    {
        private readonly WebApiDBContext _context;

        public UserTypeController(WebApiDBContext context)
        {
            _context = context;
        }
        //Get a list of products
        [HttpGet]
        public ActionResult<List<UserType>> Get()
        {
            var lstUserTypes = _context.UserTypes.ToList();
            if (lstUserTypes.Count > 0)
            {
                return lstUserTypes;
            }
            var error = returnObject("Can't find any user type", 404, 0);
            return NotFound(error);
        }
        // GET api/usertype/5
        [HttpGet("{id}")]
        public ActionResult<UserType> Get(int id)
        {
            var res = _context.UserTypes.Where(x => x.UserTypeId == id).FirstOrDefault();
            if (res != null)
            {
                return res;
            }
            var error = returnObject("User type not found", 404, 0);
            return NotFound(error);
        }

        // POST api/usertype
        [HttpPost]
        public IActionResult Post([FromBody] UserType user)
        {
            try
            {
                _context.Add(user);
                _context.SaveChanges();
                var message = returnObject("User type added correctly", 200, 1);
                return Ok(message);
            }
            catch (Exception ex)
            {
                string e = ex.Message;
                var error = returnObject(e, 400, 0);
                return BadRequest(error);
            }
        }

        // PUT api/usertype
        [HttpPut]
        public IActionResult Put([FromBody] UserType user)
        {
            try
            {
                UserType _user = _context.UserTypes.FirstOrDefault(x => x.UserTypeId == user.UserTypeId);
                _user.UserTypeName = user.UserTypeName;
                _context.SaveChanges();
                var message = returnObject("User type modified correctly", 200, 1);
                return Ok(message);
            }
            catch (Exception ex)
            {
                string e = ex.Message;
                var error = returnObject(e, 400, 0);
                return BadRequest(error);
            }
        }

        // DELETE api/usertype/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            UserType user = _context.UserTypes.Find(id);
            if (user == null)
            {
                var error = returnObject("User type not found", 404, 0);
                return NotFound(error);
            }
            _context.UserTypes.Remove(user);
            _context.SaveChanges();
            var message = returnObject("User type deleted correctly", 200, 1);
            return Ok(message);
        }
    }
}
