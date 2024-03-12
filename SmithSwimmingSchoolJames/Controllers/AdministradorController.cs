using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmithSwimmingSchoolJames.Data;
using SmithSwimmingSchoolJames.Models;

namespace SmithSwimmingSchoolJames.Controllers
{

    [Authorize(Roles = "Admin,Coach")]

    public class AdministradorController : Controller
    {

        private readonly ApplicationDbContext _db;

        public AdministradorController(ApplicationDbContext db)
        {
            _db = db;
        }






        public async Task <IActionResult> Index()
        {

            ViewData["Registrado"] = false;

            if (User.Identity.Name != null)
            {
                var admin = await _db.Administradors.FirstOrDefaultAsync(i => i.AdministradorUser == User.Identity.Name);

                if (admin != null)
                {
                    ViewBag.AdministradorId = admin.AdministratorId;
                    ViewData["Registrado"] = true;
                }
            }

            return View();
        }

        [Authorize(Roles ="Admin")]
    public async Task<IActionResult> AllProfiles()
        {
            var admin = await _db.Administradors.ToListAsync();
            return View(admin);


        }


        public IActionResult AddProfile()

        { 
            return View(); 
        }

        [HttpPost]

        public async Task<IActionResult> AddProfile(Administrador administrador)
        {
            _db.Add(administrador);
            await _db.SaveChangesAsync();
            return RedirectToAction("AllProfiles");


        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditProfile(int id)
        {
            var adminToUpadate = await _db.Administradors.FirstOrDefaultAsync(i => i.AdministratorId == id);
            return View(adminToUpadate);
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(Administrador admin)
        {
            _db.Update(admin);
            await _db.SaveChangesAsync();
            return RedirectToAction("AllProfiles");
        }




    }
}
