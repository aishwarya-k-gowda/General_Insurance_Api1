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
    public class ClaimController : ControllerBase
    {
        //Necessary code to create the DbContext object properly.
        private readonly General_Insurance6Context _context;

        public ClaimController(General_Insurance6Context context)
        {
            _context = context;
        }

        //Action method to return list of all claimreason
        [HttpGet]
        public IEnumerable<Claimreason> GetAll()
        {
            return _context.Claimreasons.ToList();
        }

        //Action method to returnclaimreason details by ClaimId
        [HttpGet("claimreason/{id}")]
        public IEnumerable<Claimreason> GetById(int id)
        {
            IEnumerable<Claimreason> res = from c in _context.Claimreasons
                                           where c.ClaimId == id
                                           select c;
            return res;
        }


        //Action method to store the data/create the records.
        [HttpPost("Addclaim")]
        public IActionResult Create([FromBody] Claimreason claimreason)
        {
            var obj = _context.Claimreasons.Find(claimreason.ClaimId);
            if (claimreason == null || obj != null)
                return BadRequest();


            _context.Claimreasons.Add(claimreason);
            _context.SaveChanges();

            //Verifying if player details are stored correctly.
            return CreatedAtAction("GetById", new { id = claimreason.ClaimId }, claimreason);
        }


        //Action method to delete Claimreason data.
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var obj = _context.Claimreasons.Find(id);

            if (obj == null)
                return NotFound();

            _context.Claimreasons.Remove(obj);
            _context.SaveChanges();

            return new NoContentResult();
        }



    }
}