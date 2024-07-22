using AdvancedProgrammingWeb.ViewModel;
using APW.Architecture;
using APW.DataSource;
using APW.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvancedProgrammingWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController(IVehicleSource vehicleSource) : ControllerBase
    {
        private readonly IVehicleSource _vehicleSource = vehicleSource;

        // GET: api/<VehicleController>
        [HttpGet("all")]
        public IEnumerable<CarViewModel> GetAll()
        {
            return null;
        }

        // GET api/<VehicleController>/5
        [HttpGet("{id}")]
        public Car Get(string id)
        {
            return null;
        } 

        // POST api/<VehicleController>
        [HttpPost]
        public IEnumerable<CarViewModel> Post([FromBody] CarViewModel carViewModel)
        {
            return null;
        }

        // PUT api/<VehicleController>/5
        [HttpPut("{id}")]
        public CarViewModel Put(string id, [FromBody] CarViewModel carViewModel)
        {
            return null;
        }

        // DELETE api/<VehicleController>/5
        [HttpDelete("{id}")]
        public IEnumerable<CarViewModel> Delete(string id)
        {
            return null;
        }
    }
}
