using EventsApp.Data;
using EventsApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApp.Controllers
{
    public class EventController : Controller
    {
        private ApplicationContext _context;

        public EventController(ApplicationContext context)
        {
            _context = context;
        }
        // GET: Events
        public ActionResult Index()
        {
            return View();
        }

        // GET: Events/Details/5
        public ActionResult Details(int id)
        {
            var appEvent = _context.Events.Where(e => e.Id == id).FirstOrDefault();
            return View(appEvent);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Event eventApp)
        {
            try
            {
                var result = await _context.AddAsync(eventApp);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Event newEvent)
        {
            try
            {
                Event appEvent = _context.Events.Where(op => op.Id == id).FirstOrDefault();
                appEvent.Name = newEvent.Name;
                appEvent.Time = newEvent.Time;
                appEvent.Description = newEvent.Description;
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Events/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Event eventToDelete)
        {
            try
            {
                _context.Events.Remove(_context.Events.Where(op => op.Id == eventToDelete.Id).FirstOrDefault()); 

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}