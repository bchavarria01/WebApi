using System;
using System.Collections.Generic;
using System.Linq;
using BCWebApi.Context;
using BCWebApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace BCWebApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly WebApiDBContext _context;

        public UserController(WebApiDBContext context)
        {
            _context = context;
        }
        //Get a list of products
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            var lstUsers = _context.Users.ToList();
            if (lstUsers.Count > 0)
            {
                return lstUsers;
            }
            var error = returnObject("Cant find any user", 404, 0);
            return NotFound(error);
        }
        // GET api/user/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var res = _context.Users.Where(x => x.UserId == id).FirstOrDefault();
            if (res != null)
            {
                return res;
            }
            var error = returnObject("User not found", 404, 0);
            return NotFound(error);
        }

        // POST api/user
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                _context.Add(user);
                _context.SaveChanges();
                var message = returnObject("User added correctly", 200, 1);
                return Ok(message);
            }
            catch (Exception ex)
            {
                string e = ex.Message;
                var error = returnObject(e, 400, 0);
                return BadRequest(error);
            }
        }

        // PUT api/user/5
        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            try
            {
                User _user = _context.Users.FirstOrDefault(x => x.UserId == user.UserId);
                _user.UserName = user.UserName;
                _user.UserPassword = user.UserPassword;
                _user.UserTypeId = user.UserTypeId;
                _context.Users.Update(_user);
                _context.SaveChanges();
                var message = returnObject("User modified correctly", 200, 1);
                return Ok(message);
            }
            catch (Exception ex)
            {
                string e = ex.Message;
                var error = returnObject(e, 400, 0);
                return BadRequest(error);
            }
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User user = _context.Users.Find(id);
            if (user == null)
            {
                var error = returnObject("User not found", 404, 0);
                return NotFound(error);
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            var message = returnObject("User deleted correctly", 200, 1);
            return Ok(message);
        }
    }
}
