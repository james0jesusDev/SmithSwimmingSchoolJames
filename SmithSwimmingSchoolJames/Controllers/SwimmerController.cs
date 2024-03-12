using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmithSwimmingSchoolJames.Data;
using SmithSwimmingSchoolJames.Models; // Asegúrate de tener este espacio de nombres importado
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmithSwimmingSchoolJames.Controllers
{
    [Authorize(Roles = "Admin,Alumno")]
    public class SwimmerController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SwimmerController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Registrado"] = false;

            if (User.Identity.Name != null)
            {
                var student = await _db.Students.FirstOrDefaultAsync(i => i.StudentUser == User.Identity.Name);

                if (student != null)
                {
                    ViewBag.AdministradorId = student.StudentId;
                    ViewData["Registrado"] = true;
                }
            }

            return View();
        }

        // Acción para mostrar los informes de progreso del nadador
        [Authorize(Roles = "Alumno")]
        public async Task<IActionResult> VerReports()
        {
            var progressReports = await _db.ProgressReports.ToListAsync();
            return View(progressReports);
        }
    }
}
