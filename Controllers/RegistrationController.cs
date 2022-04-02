using Gladiator_General_InsuranceApi3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gladiator_General_InsuranceApi3.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        //Necessary code to create the DbContext object properly.
        private readonly General_Insurance6Context _context;

        public RegistrationController(General_Insurance6Context context)
        {
            _context = context;
        }

        //Action method to return list of all players.
        [HttpGet]
        public IEnumerable<UserRegistration> GetAll()
        {
            return _context.UserRegistrations.ToList();
        }

        //Action method to return player details by jersey number.
        [HttpGet("userdetails/{id}")]
        public IEnumerable<UserRegistration> GetById(int id)
        {
            IEnumerable<UserRegistration> res = from r in _context.UserRegistrations
                                                where r.UserId == id
                                                select r;
            return res;
        }


        //Action method to store the data/create the records.
        [HttpPost("register")]
        public IActionResult Create([FromBody] UserRegistration userRegistration)
        {
            var obj = _context.UserRegistrations.Find(userRegistration.UserId);
            if (userRegistration == null || obj != null)
                return BadRequest();


            _context.UserRegistrations.Add(userRegistration);
            _context.SaveChanges();

            //Verifying if player details are stored correctly.
            return CreatedAtAction("GetById", new { id = userRegistration.UserId }, userRegistration);
        }

        [HttpPost("login/{Email}/{password}")]
        public IActionResult Login(string email, string password)
        {
            var obj = _context.Logins.Where(r => r.Email == email && r.Password == password).FirstOrDefault();
            if (obj == null)
            {

                return Ok("Record Not Found");
            }

            else
            {
                return Ok();
            }



        }

       

        //Action method to delete player data.
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var obj = _context.UserRegistrations.Find(id);

            if (obj == null)
                return NotFound();

            _context.UserRegistrations.Remove(obj);
            _context.SaveChanges();

            return new NoContentResult();
        }

        //[HttpPost("login/{id}/{email}")]
        //public IActionResult Login(int id, string email)
        //{
        //    var obj = _context.UserRegistrations.Where(u => u.UserId == id && u.Email == email).FirstOrDefault();
        //    if (obj == null)
        //    {

        //        return Ok("Record Not Found");
        //    }

        //    else
        //    {
        //        return Ok();
        //    }





        //}

    }
}
