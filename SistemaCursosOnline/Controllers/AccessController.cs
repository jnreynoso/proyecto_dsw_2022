using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SistemaCursosOnline.Models;
using System.Diagnostics;

using SistemaCursosOnline.Data;
using Microsoft.EntityFrameworkCore;

namespace SistemaCursosOnline.Controllers
{
    public class AccessController : Controller
    {
        private string session = "";

        private readonly SCOnlineContext _context;

        private readonly ILogger<HomeController> _logger;

       public AccessController(SCOnlineContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        private AccesResult verify_access(string dni, string pass)
        {
            TbUser tbUser = _context.TbUser.FirstOrDefault(x => x.dni == dni && x.password == pass);
            Alumn alumn = _context.Alumn.FirstOrDefault(x => x.dni == dni && x.password == pass);

            AccesResult result = new AccesResult();

            if (tbUser is null && alumn is null)
            {
                result.success = false;
                result.message = "Usuario o clave incorrecta";

                return result;
            }

            if (tbUser.id < 100)
            {
                result.success = true;
                result.message = "Bienvenido " + tbUser.names;

                return result;
            }
            else if (alumn.id > 99)
            {
                result.success = true;
                result.message = "Bienvenido" + alumn.name + ' ' + alumn.lastname;

                return result;

            } else
            {
                result.success = false;
                result.message = "Usuario o clave incorrecta";

                return result;
            }
        }

        public async Task<IActionResult> Login()
        {
            HttpContext.Session.SetString(session, "");

            return View(await Task.Run(() => new TbUser()));
        }

        [HttpPost]
        public async Task<IActionResult> Login(TbUser reg)
        {
            AccesResult sw = verify_access(reg.dni, reg.password);

            if (sw.success)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", HttpContext.Session.GetString(session));

                ViewBag.message = sw.message;

                return View(await Task.Run(() => reg));
            }
        }


    }
}
