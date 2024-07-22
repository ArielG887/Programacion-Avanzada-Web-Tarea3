using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APW.Data.Models;

namespace APW.Web.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly ApdatadbContext _context;

        public NotificationsController(ApdatadbContext context)
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

        // GET: Notifications
        public async Task<IActionResult> Index()
        {
            var apdatadbContext = _context.Notifications.Include(n => n.User);
            var randomUser = await GetRandomUserAsync();
            ViewData["RandomUser"] = randomUser;
            return View(await apdatadbContext.ToListAsync());
            
        }

        public async Task<IActionResult> CardView()
        {
            var notifications = await _context.Notifications.Include(n => n.User).ToListAsync();
            var randomUser = await GetRandomUserAsync();
            ViewData["RandomUser"] = randomUser;
            return View(notifications);
        }


        // GET: Notifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications
                .Include(n => n.User)
                .FirstOrDefaultAsync(m => m.NotificationId == id);
            if (notification == null)
            {
                return NotFound();
            }
            var randomUser = await GetRandomUserAsync();
            ViewData["RandomUser"] = randomUser;

            return View(notification);
        }

        // GET: Notifications/Create
        public async Task<IActionResult> Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");
            var randomUser = await GetRandomUserAsync();
            ViewData["RandomUser"] = randomUser;
            return View();
        }

        // POST: Notifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NotificationId,UserId,Message,IsRead,CreatedAt")] Notification notification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", notification.UserId);
           
            return View(notification);
        }

        // GET: Notifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", notification.UserId);
            var randomUser = await GetRandomUserAsync();
            ViewData["RandomUser"] = randomUser;
            return View(notification);
        }

        // POST: Notifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NotificationId,UserId,Message,IsRead,CreatedAt")] Notification notification)
        {
            if (id != notification.NotificationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificationExists(notification.NotificationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", notification.UserId);
            var randomUser = await GetRandomUserAsync();
            ViewData["RandomUser"] = randomUser;
            return View(notification);
        }

        // GET: Notifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications
                .Include(n => n.User)
                .FirstOrDefaultAsync(m => m.NotificationId == id);
            if (notification == null)
            {

                
                return NotFound();
            }
            var randomUser = await GetRandomUserAsync();
            ViewData["RandomUser"] = randomUser;
            return View(notification);
        }

        // POST: Notifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification != null)
            {
                _context.Notifications.Remove(notification);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotificationExists(int id)
        {
            return _context.Notifications.Any(e => e.NotificationId == id);
        }
    }
}
