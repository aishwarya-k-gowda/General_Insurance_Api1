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
    public class DurationController : ControllerBase
    {
        //Necessary code to create the DbContext object properly.
        private readonly General_Insurance6Context _context;

        public DurationController(General_Insurance6Context context)
        {
            _context = context;
        }
        // GET: api/<DurationController>
        [HttpGet]
        public IEnumerable<Insuranceduration> GetAll()
        {
            return _context.Insurancedurations.ToList();
        }
        [HttpGet("Durationtype/{id}")]
        public IEnumerable<Insuranceduration> GetById(int id)
        {
            IEnumerable<Insuranceduration> res = from idu in _context.Insurancedurations
                                                 where idu.DurationId == id
                                                 select idu;
            return res;
        }

        [HttpPost("AddDurationtype")]
        public IActionResult Create([FromBody] Insuranceduration insuranceduration)
        {
            var obj = _context.Insurancedurations.Find(insuranceduration.DurationId);
            if (insuranceduration == null || obj != null)
                return BadRequest();


            _context.Insurancedurations.Add(insuranceduration);
            _context.SaveChanges();

            //Verifying if player details are stored correctly.
            return CreatedAtAction("GetById", new { id = insuranceduration.DurationId }, insuranceduration);
        }


        // DELETE api/<PlansController>/5
        [HttpDelete("durationtype{id}")]
        public IActionResult Delete(int id)
        {
            var obj = _context.Insurancedurations.Find(id);

            if (obj == null)
                return NotFound();

            _context.Insurancedurations.Remove(obj);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }
}
