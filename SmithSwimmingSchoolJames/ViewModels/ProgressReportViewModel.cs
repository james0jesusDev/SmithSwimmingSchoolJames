using SmithSwimmingSchoolJames.Models;
using System.ComponentModel.DataAnnotations;

namespace SmithSwimmingSchoolJames.ViewModels
{
    public class ProgressReportViewModel
    {
        public int StudentId { get; set; }

        public string? StudentName { get; set; }

        public int CoachId { get; set; } 


        public string? Content { get; set; }

        public string? Comments { get; set; }

        public IEnumerable<Student>? Students { get; set; }
        public IEnumerable<Coach>? Coaches { get; set; }
    }
}
