namespace SmithSwimmingSchoolJames.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; } 
        public virtual Student? Student { get; set; } 
        public int GroupId { get; set; } 
        public virtual Group? Group { get; set; }
    }
}
