using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmithSwimmingSchoolJames.Data;
using SmithSwimmingSchoolJames.Models;
using SmithSwimmingSchoolJames.ViewModels;
using System.Security.Claims;

namespace SmithSwimmingSchoolJames.Controllers
{


    // Control de cambios , coach nos falta el ver asistentes  


    [Authorize(Roles = "Admin,Coach")]
    public class CoachController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CoachController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Registrado"] = false;

            if (User.Identity.Name != null)
            {
                var coach = await _db.Coachs.FirstOrDefaultAsync(i => i.CoachUser == User.Identity.Name);

                if (coach != null)
                {
                    ViewBag.AdministradorId = coach.CoachId;
                    ViewData["Registrado"] = true;
                }
            }

            return View();
        }




        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> AllProfiles()
        {
            var admin = await _db.Coachs.ToListAsync();
            return View(admin);


        }

        [Authorize(Roles = "Coach")]
        public IActionResult AddProfile()

        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddProfile(Coach administrador)
        {
            _db.Add(administrador);
            await _db.SaveChangesAsync();
            return RedirectToAction("AllProfiles");


        }

        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> EditProfile(int id)
        {
            var adminToUpadate = await _db.Coachs.FirstOrDefaultAsync(i => i.CoachId == id);
            return View(adminToUpadate);
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(Coach admin)
        {
            _db.Update(admin);
            await _db.SaveChangesAsync();
            return RedirectToAction("AllProfiles");



        }
        // Segundo
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> AddReport()
        {
            var students = await _db.Students.ToListAsync();
            var coaches = await _db.Coachs.ToListAsync(); // Obtener todos los coaches disponibles
            var currentCoachId = GetCurrentCoachId();
            var viewModel = new ProgressReportViewModel
            {
                Students = students,
                CoachId = currentCoachId,
                Coaches = coaches // Asigna la lista de coaches al modelo
            };
            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> AddReport(ProgressReportViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Creando un nuevo informe de progreso
                var progressReport = new ProgressReport
                {
                    CoachId = model.CoachId, // Asignando el CoachId seleccionado
                    StudentId = model.StudentId,
                    Content = model.Content,
                    CreatedAt = DateTime.Now,
                };

                _db.ProgressReports.Add(progressReport);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            var students = await _db.Students.ToListAsync();
            var coaches = await _db.Coachs.ToListAsync(); 
            model.Students = students; 
            model.Coaches = coaches; 
            return View(model);
        }


        private int GetCurrentCoachId()// metodo para coger el id 
        {
            var claim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (claim != null && int.TryParse(claim.Value, out int currentCoachId))
            {
                return currentCoachId;
            }
            return 0; 
        }




        [Authorize(Roles = "Coach")]
        public async Task<IActionResult> VerAsistentes()
        {
            var currentCoachId = GetCurrentCoachId();

            // Obtener los asistentes a la clase del entrenador actual
            var attendees = await _db.Coachs
                .Where(s => s.CoachId == currentCoachId) 
                .Select(s => new ClassAttendeesViewModel
                {
                    StudentName = s.Name,
                    AttendanceDate = DateTime.Now // Puedes ajustar esto según tu lógica
                })
                .ToListAsync();

            return View(attendees);
        }


    }

}

