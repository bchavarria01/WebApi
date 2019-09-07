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
    public class UserController : Controller
    {
        private readonly WebApiDBContext _context;

        public UserController(WebApiDBContext context)
        {
            _context = context;
        }
        //Get a list of products
        [HttpGet]
        public List<User> Get()
        {
            return _context.Users.ToList();
        }
        // GET api/user/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return _context.Users.Where(x => x.UserId == id).FirstOrDefault();
        }

        // POST api/user
        [HttpPost]
        public void Post([FromBody] User user)
        {
            try
            {
                _context.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string e = ex.Message;
            }
        }

        // PUT api/user/5
        [HttpPut]
        public void Put([FromBody] User user)
        {
            try
            {
                User _user = _context.Users.FirstOrDefault(x => x.UserId == user.UserId);
                _user.UserName = user.UserName;
                _user.UserPassword = user.UserPassword;
                _user.UserTypeId = user.UserTypeId;
                _context.Users.Update(_user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string e = ex.Message;
            }
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            User user = _context.Users.Find(id);
            if (user == null)
            {
                return;
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
