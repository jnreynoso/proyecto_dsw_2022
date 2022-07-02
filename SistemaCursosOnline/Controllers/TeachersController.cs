using Microsoft.AspNetCore.Mvc;
using SistemaCursosOnline.Models;
using System.Diagnostics;

using SistemaCursosOnline.Data;
using Microsoft.EntityFrameworkCore;

namespace SistemaCursosOnline.Controllers
{
    public class TeachersController : Controller
    {

        private readonly SCOnlineContext _context;

        private readonly ILogger<HomeController> _logger;

        public TeachersController(SCOnlineContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
