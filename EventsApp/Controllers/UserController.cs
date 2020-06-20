using EventsApp.Data;
using EventsApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(ApplicationContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        [Authorize]
        public ActionResult Details(string? username)
        {
            string _username;
            if (username == null)
            {
                _username = User.Identity.Name;
            }
            else
            {
                _username = username;
            }

            var user = _context.ApplicationUsers.Where(op => op.UserName == _username).FirstOrDefault();
            List<Event> events = new List<Event>();
            foreach (var appUserEvent in _context.ApplicationUserEvents.Where(op => op.ApplicationUserId == user.Id).ToList())
            {
                events.Add(_context.Events.Where(op => op.Id == appUserEvent.EventId).FirstOrDefault());
            }
            ViewBag.Events = events;
            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        public async Task<IActionResult> AddEvent(int id)
        {

            string userId = _context.ApplicationUsers.Where(op => op.UserName == User.Identity.Name).FirstOrDefault().Id;
            if (userId == null) userId = "100";
              await _context.ApplicationUserEvents.AddAsync(new ApplicationUserEvent { ApplicationUserId = userId, EventId = id });
              await _context.SaveChangesAsync();
              return RedirectToAction("Details");      
            
        }
    }
}