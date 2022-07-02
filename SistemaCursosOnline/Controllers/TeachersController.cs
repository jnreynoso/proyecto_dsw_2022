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

        public async Task<IActionResult> Index()
        {
            List<CoursesGroupByTeacher> results;

            if (_context.Teacher != null)
            {
                results = await _context.TeacherCourse
                    .Include(x => x.Course)
                    .Include(x => x.Teacher)
                    .GroupBy(x => x.teacherId)
                    .Select(x => new CoursesGroupByTeacher{
                        teacherId = x.Key,
                        nameTeacher = x.FirstOrDefault(y => y.teacherId == x.Key).Teacher.names ,
                        photoTeacher= x.FirstOrDefault(y => y.teacherId == x.Key).Teacher.photo_url,
                        teacherAndCourse = x.ToList()
                    })
                    .ToListAsync();

                _logger.LogInformation(results.ToString());
            } else
            {
                return Problem("Entity set 'SCOnlineContext.Teachers'  is null.");
            }


            return View(results);
        }
    }
}
