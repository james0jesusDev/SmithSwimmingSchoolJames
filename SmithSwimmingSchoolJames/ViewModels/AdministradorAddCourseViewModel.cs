using Microsoft.AspNetCore.Mvc.Rendering;
using SmithSwimmingSchoolJames.Models;

namespace SmithSwimmingSchoolJames.ViewModels
{
    public class AdministradorAddCourseViewModel
    {

        public Course? Course { get; set; }

        public Administrador? Administrador { get; set; }
        public Instructor? Instructor { get; set; }

        public List<Group> Groups { get; set; }

        public SelectList? AdministradorList { get; set; }
        public SelectList? InstructorList { get; set; }

    }
}
