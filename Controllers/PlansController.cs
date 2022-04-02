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
    public class PlansController : ControllerBase
    {
        //Necessary code to create the DbContext object properly.
        private readonly General_Insurance6Context _context;

        public PlansController(General_Insurance6Context context)
        {
            _context = context;
        }
        // GET: api/<PlansController>
        [HttpGet]
        public IEnumerable<Insuranceplantype> GetAll()
        {
            return _context.Insuranceplantypes.ToList();
        }
        [HttpGet("Plantype/{id}")]
        public IEnumerable<Insuranceplantype> GetById(int id)
        {
            IEnumerable<Insuranceplantype> res = from ip in _context.Insuranceplantypes
                                                 where ip.PlanId == id
                                                 select ip;
            return res;
        }

        [HttpPost("AddPlantype")]
        public IActionResult Create([FromBody] Insuranceplantype insuranceplantype)
        {
            var obj = _context.Insuranceplantypes.Find(insuranceplantype.PlanId);
            if (insuranceplantype == null || obj != null)
                return BadRequest();


            _context.Insuranceplantypes.Add(insuranceplantype);
            _context.SaveChanges();

            //Verifying if player details are stored correctly.
            return CreatedAtAction("GetById", new { id = insuranceplantype.PlanId }, insuranceplantype);
        }


        //Action method to delete player data.
        [HttpDelete("plantype{id}")]
        public IActionResult Delete(int id)
        {
            var obj = _context.Insuranceplantypes.Find(id);

            if (obj == null)
                return NotFound();

            _context.Insuranceplantypes.Remove(obj);
            _context.SaveChanges();

            return new NoContentResult();
        }

       
    }
    
}
