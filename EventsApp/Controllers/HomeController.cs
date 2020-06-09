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
        private UserManager<ApplicationUser> _userManager;
        private ApplicationContext _context;
        private SignInManager<ApplicationUser> _signInManager;

        public HomeController(UserManager<ApplicationUser> userManager, ApplicationContext context, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;


        }

        public IActionResult Index()
        {
            return View(_context.Events.ToList());
        }

        //GET /Home/Register
        public IActionResult Register()
        {
            return View();
        }

        //POST /Home/Register
        [HttpPost]
        public async Task<IActionResult> Register(string username, string email, string password)
        {
            var user = new ApplicationUser
            {
                UserName = username,
                Email = email
            };
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Проверьте правильность полей";
                return View();
            }

        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(username, password, true, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = result.ToString();
                    return View();
                }
            }
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout() 
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
