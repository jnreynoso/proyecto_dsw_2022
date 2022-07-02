using Microsoft.AspNetCore.Mvc;
using SistemaCursosOnline.Models;
using SistemaCursosOnline.Data;
using Microsoft.EntityFrameworkCore;

namespace SistemaCursosOnline.Controllers
{
    public class ScheduleAvailableController : Controller
    {

        private readonly SCOnlineContext _context;

        private readonly ILogger<HomeController> _logger;

       public ScheduleAvailableController(SCOnlineContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<IActionResult> Index(int courseId)
        {
            List<TeacherScheduling> availables;

            Course courseSelected = _context.Courses.FirstOrDefault(x => x.id == courseId);

            ViewBag.courseName = courseSelected.name;

            if (_context.TeacherScheduling != null)
            {
                availables = await _context.TeacherScheduling.Include(x => x.Teacher).Include(x => x.Schedule).Where(x => x.courseId == courseId).ToListAsync();

                _logger.LogInformation(availables.ToString());
            } else
            {
                return Problem("Entity set 'SCOnlineContext.Courses'  is null.");
            }

            return View(availables);
        }
    }
}
