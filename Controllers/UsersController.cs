using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        public static List<user> users = new List<user>();

        [HttpGet]

        public IActionResult Get()
        {
            return Ok(users);
        }
        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            var User = users.SingleOrDefault(u => u.name == name);
            if (User == null)
            {
                return NotFound();
            }
            return Ok(User);
        }
        [HttpPost]
        public IActionResult Post(user u)
        {
            var User = new user
            {
                name = u.name,
                password = u.password,
                mail = u.mail,
                age = u.age,
                phonenumber = u.phonenumber,
            };
            users.Add(User);
            return Ok(new
            {
                Success = true,
                data = User,
            });
        }
        [HttpPut("{name}")]
        public IActionResult Put(string name, user u)
        {
            var User = users.SingleOrDefault(u => u.name == name);
            if (User == null)
            {
                return NotFound();
            }
            User.name = u.name;
            User.password = u.password;
            User.mail = u.mail;
            User.age = u.age;
            User.phonenumber = u.phonenumber;
            return Ok();

        }
        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            var User = users.SingleOrDefault(u => u.name == name);
            if (User == null)
            {
                return NotFound();
            }
            users.Remove(User);
            return Ok();
        }

    }
}
