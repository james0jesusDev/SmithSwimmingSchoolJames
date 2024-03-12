using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmithSwimmingSchoolJames.Data;
using SmithSwimmingSchoolJames.Models;

namespace SmithSwimmingSchoolJames.Controllers
{
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
    }
}
