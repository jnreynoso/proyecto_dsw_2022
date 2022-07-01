using Microsoft.AspNetCore.Mvc;
using SistemaCursosOnline.Models;
using System.Diagnostics;

using SistemaCursosOnline.Data;
using Microsoft.EntityFrameworkCore;

namespace SistemaCursosOnline.Controllers
{
    public class HomeController : Controller
    {

        private readonly SCOnlineContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(SCOnlineContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<Courses> courses;


            if (_context.Courses != null)
            {
                courses = await _context.Courses.Include(x => x.Schedule).ToListAsync();

                _logger.LogInformation(courses.ToString());
            } else
            {
                return Problem("Entity set 'SCOnlineContext.Courses'  is null.");
            }

            return View(courses);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}