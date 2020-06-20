using EventsApp.Data;
using EventsApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApp.Cotrollers
{
    public class HomeController : Controller
    {
        private ApplicationContext _context;
        public HomeController(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Events.ToList());
        }
    }
}
