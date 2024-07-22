using APW.Data.Models;
using APW.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace APW.Web.Controllers
{


    public class UserController : Controller
    {

        private readonly ApdatadbContext _context;

        public UserController(ApdatadbContext context)
        {
            _context = context;
        }

        private async Task<string> GetRandomUserAsync()
        {
            var users = await _context.Users.Select(u => u.Username).ToListAsync();
            if (users.Count == 0)
            {
                return "Guest";
            }

            var random = new Random();
            return users[random.Next(users.Count)];
        }

        // GET: UserController
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            var randomUser = await GetRandomUserAsync();
            ViewData["RandomUser"] = randomUser;
            return View(users);
        }


        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/create
        public async Task<IActionResult> Create()
        {
            var randomUser = await GetRandomUserAsync();
            ViewData["RandomUser"] = randomUser;
            return View();
        }

        // GET: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));

        }

        //[HttpPost]
        //public ActionResult Register([FromBody] UserViewModel userViewModel)
        //{
        //    return View();
        //}

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
