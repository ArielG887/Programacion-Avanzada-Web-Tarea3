using AdvancedProgrammingWeb.ViewModel;
using APW.Architecture;
using APW.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvancedProgrammingWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestController(IRestProvider restProvider, IProcess proces) : ControllerBase
    {
        private readonly IRestProvider _restProvider = restProvider;
        private readonly IProcess _proces = proces;

        // GET: api/<RestController>
        [HttpGet("all")]
        public async Task<object> GetAll()
        {
            var response = await _restProvider.GetAsync($"https://localhost:7154/api/Vehicle/", "all");
            return response;
        }

        // GET: api/<RestController>
        [HttpGet]
        public async Task<object> Get(string id)
        {
            var response = await _restProvider.GetAsync($"https://localhost:7154/api/Vehicle/", id);
            return response;
        }
        
        // POST api/<RestController>
        [HttpPost]
        public async Task<string> Post([FromBody] CarViewModel car)
        {
            var response = await _restProvider.PostAsync($"https://localhost:7154/api/Vehicle/",
                JsonProvider.Serialize(CarViewModel.FromCarViewModelToCar(car)));
            return response;
        }

        // PUT api/<RestController>/5
        [HttpPut("{id}")]
        public async Task<string> Put([FromBody] CarViewModel car, string id)
        {
            var response = await _restProvider.PutAsync($"https://localhost:7154/api/Vehicle/", id,
                JsonProvider.Serialize(CarViewModel.FromCarViewModelToCar(car)));
            return response;
        }

        // DELETE api/<RestController>/5
        [HttpDelete("{id}")]
        public async Task<string> Delete(string id)
        {
            var response = await _restProvider.DeleteAsync($"https://localhost:7154/api/Vehicle/", id);
            return response;
        }

        [HttpGet]
        public void ProcessTask()
        {
            // ITransaction transaction = new Transaction();
            // new X
            // new Y
            // new Z
            // var processTAsk = new Process();

            _proces.ProcessTask();
        }
    }
}
