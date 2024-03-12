using Microsoft.AspNetCore.Mvc.Rendering;
using SmithSwimmingSchoolJames.Models;
using System.Collections.Generic;

namespace SmithSwimmingSchoolJames.ViewModels
{
    public class AdministratorAssignGroupViewModel
    {
        public Course? Course { get; set; }

        public Group? Group { get; set; }
        public int CoachId { get; set; }
        public Coach? Coach { get; set; }

        public Instructor? Instructor { get; set; }
        public SelectList? CoachList { get; set; }
        public SelectList? InstructorList { get; set; }
    }
}
