using APW.Architecture;
using APW.Data.Models;
using APW.Models;
using APW.Service;
using APW.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace APW.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRestApwService _restApwService;
        private readonly ApdatadbContext _context;

        public HomeController(ILogger<HomeController> logger, IRestApwService restApwService, ApdatadbContext context)
        {
            _logger = logger;
            _restApwService = restApwService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogDebug("Test");

            var result = await _restApwService.GetApwServiceAsync();
            IEnumerable<RootDto> roots = JsonProvider.DeserializeSimple<RootDto[]>(result as string) ?? Enumerable.Empty<RootDto>();

            var randomUser = await GetRandomUserAsync();
            ViewData["RandomUser"] = randomUser;

            return View(roots);
        }

        public async Task<IActionResult> Privacy()
        {
            var randomUser = await GetRandomUserAsync();
            ViewData["RandomUser"] = randomUser;

            return View();
        }

        private async Task<string> GetRandomUserAsync()
        {
            var users = await _context.Users.Select(u => u.Username).ToListAsync();
            _logger.LogDebug($"Number of users found: {users.Count}");

            if (users.Count == 0)
            {
                return "Guest";
            }

            var random = new Random();
            var randomUsername = users[random.Next(users.Count)];
            _logger.LogDebug($"Random user selected: {randomUsername}");
            return randomUsername;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

