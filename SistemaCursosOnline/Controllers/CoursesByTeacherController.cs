using Microsoft.AspNetCore.Mvc;
using SistemaCursosOnline.Models;
using System.Diagnostics;

using SistemaCursosOnline.Data;
using Microsoft.EntityFrameworkCore;

namespace SistemaCursosOnline.Controllers
{
    public class CoursesByTeacherController : Controller
    {
        private readonly SCOnlineContext _context;

        private readonly ILogger<HomeController> _logger;

       public CoursesByTeacherController(SCOnlineContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IActionResult> Index(int teacherId)
        {
            List<TeacherScheduling> availables;

            Teacher teacherSelected = _context.Teacher.FirstOrDefault(x => x.id == teacherId);

            ViewBag.teacherName = teacherSelected.names;
            ViewBag.cv_url = teacherSelected.cv_url;

            if (_context.TeacherCourse != null)
            {
                availables = await _context.TeacherScheduling
                    .Where(x => x.teacherId == teacherId)
                    .Include(x => x.Course)
                    .Include(x => x.Schedule)
                    .ToListAsync();

                _logger.LogInformation(availables.ToString());
            } else
            {
                return Problem("Entity set 'SCOnlineContext.TeacherCourse'  is null.");
            }

            return View(availables);
        }
    }
}
