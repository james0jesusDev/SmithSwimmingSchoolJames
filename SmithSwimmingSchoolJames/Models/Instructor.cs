namespace SmithSwimmingSchoolJames.Models
{
    public class Instructor
    {

        public int InstructorId { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }


        
        public virtual ICollection<Course>? Courses { get; set; }
    }
}
