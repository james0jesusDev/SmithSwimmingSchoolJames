namespace SmithSwimmingSchoolJames.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string? StudentUser { get; set; }

        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual ICollection<Enrollment>? Enrollments { get; set; } 
        public virtual ICollection<ProgressReport>? ProgressReports { get; set; }
    }
}
