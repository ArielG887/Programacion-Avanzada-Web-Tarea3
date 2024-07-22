using APW.Architecture;
using APW.Models;
using APW.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APW.Web.Controllers
{
    public class ApidevController(IRestApiDevService restApiDevService) : Controller
    {
        private readonly IRestApiDevService _restApiDevService = restApiDevService;

        // GET: ApidevController
        public async Task<ActionResult> Index()
        {
            var result = await _restApiDevService.GetRestDevListAsync();
            var roots = JsonProvider.DeserializeSimple<IEnumerable<RootDto>>(result as string);
            return View(roots);
        }

        public async Task<IActionResult> Single()
        {
            var model = await _restApiDevService.GetRestDevSingleAsync(new Random().Next(10).ToString());
            var root = JsonProvider.DeserializeSimple<RootDto>(model as string);
            return PartialView("Single", root);
        }
    }
}
