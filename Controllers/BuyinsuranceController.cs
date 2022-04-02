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
    public class BuyinsuranceController : ControllerBase
    {
        //Necessary code to create the DbContext object properly.
        private readonly General_Insurance6Context _context;

        public BuyinsuranceController(General_Insurance6Context context)
        {
            _context = context;
        }

        //Action method to return list of all players.
        [HttpGet]
        public IEnumerable<Vehiclesdetail> GetAll()
        {
            return _context.Vehiclesdetails.ToList();
        }

        //Action method to return player details by jersey number.
        [HttpGet("vehicledetail/{id}")]
        public IEnumerable<Vehiclesdetail> GetById(int id)
        {
            IEnumerable<Vehiclesdetail> res = from v in _context.Vehiclesdetails
                                              where v.VehicleId == id
                                              select v;
            return res;
        }


        //Action method to store the data/create the records.
        [HttpPost("AddVehicleDetails")]
        public IActionResult Create([FromBody] Vehiclesdetail vehiclesdetail)
        {
            var obj = _context.Vehiclesdetails.Find(vehiclesdetail.VehicleId);
            if (vehiclesdetail == null || obj != null)
                return BadRequest();


            _context.Vehiclesdetails.Add(vehiclesdetail);
            _context.SaveChanges();

            //Verifying if player details are stored correctly.
            return CreatedAtAction("GetById", new { id = vehiclesdetail.VehicleId }, vehiclesdetail);
        }

        

        //Action method to delete player data.
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var obj = _context.Vehiclesdetails.Find(id);

            if (obj == null)
                return NotFound();

            _context.Vehiclesdetails.Remove(obj);
            _context.SaveChanges();

            return new NoContentResult();
        }




    }
}

