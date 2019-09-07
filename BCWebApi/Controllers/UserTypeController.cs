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
    public class UserTypeController : Controller
    {
        private readonly WebApiDBContext _context;

        public UserTypeController(WebApiDBContext context)
        {
            _context = context;
        }
        //Get a list of products
        [HttpGet]
        public List<UserType> Get()
        {
            return _context.UserTypes.ToList();
        }
        // GET api/usertype/5
        [HttpGet("{id}")]
        public ActionResult<UserType> Get(int id)
        {
            return _context.UserTypes.Where(x => x.UserTypeId == id).FirstOrDefault();
        }

        // POST api/usertype
        [HttpPost]
        public void Post([FromBody] UserType user)
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

        // PUT api/usertype
        [HttpPut]
        public void Put([FromBody] UserType user)
        {
            try
            {
                UserType _user = _context.UserTypes.FirstOrDefault(x => x.UserTypeId == user.UserTypeId);
                _user.UserTypeName = user.UserTypeName;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                string e = ex.Message;
            }
        }

        // DELETE api/usertype/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            UserType user = _context.UserTypes.Find(id);
            if (user == null)
            {
                return;
            }
            _context.UserTypes.Remove(user);
            _context.SaveChanges();
        }
    }
}
