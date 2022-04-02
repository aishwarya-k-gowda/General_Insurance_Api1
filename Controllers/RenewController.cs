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
    public class RenewController : ControllerBase
    {
        //Necessary code to create the DbContext object properly.
        private readonly General_Insurance6Context _context;

        public RenewController(General_Insurance6Context context)
        {
            _context = context;
        }

        //Action method to return list of all players.
        [HttpGet]
        public IEnumerable<Renew> GetAll()
        {
            return _context.Renews.ToList();
        }

        //Action method to return player details by jersey number.
        [HttpGet("renewdetail/{id}")]
        public IEnumerable<Renew> GetById(int id)
        {
            IEnumerable<Renew> res = from r in _context.Renews
                                     where r.RenewId == id
                                     select r;
            return res;
        }


        //Action method to store the data/create the records.
        [HttpPost("AddRenew")]
        public IActionResult Create([FromBody] Renew renew)
        {
            var obj = _context.Renews.Find(renew.RenewId);
            if (renew == null || obj != null)
                return BadRequest();


            _context.Renews.Add(renew);
            _context.SaveChanges();

            //Verifying if player details are stored correctly.
            return CreatedAtAction("GetById", new { id = renew.RenewId }, renew);
        }



        ////Action method to update player data.
        //[HttpPut("{id}")]
        //public IActionResult Update(int id, [FromBody] Renewe player)
        //{
        //    //Checking if correct id is there.
        //    if (id != player.P_Jno || player == null)
        //        return BadRequest();

        //    var obj = _context.Players.Find(id);

        //    if (obj == null)
        //        return NotFound();


        //    //Updating the values.
        //    obj.P_Name = player.P_Name;
        //    obj.P_Age = player.P_Age;
        //    obj.P_Category = player.P_Category;
        //    obj.P_Jno = player.P_Jno;

        //    _context.SaveChanges();


        //    return new NoContentResult();
        //}

        //Action method to delete player data.
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var obj = _context.Renews.Find(id);

            if (obj == null)
                return NotFound();

            _context.Renews.Remove(obj);
            _context.SaveChanges();

            return new NoContentResult();
        }

    }
}
