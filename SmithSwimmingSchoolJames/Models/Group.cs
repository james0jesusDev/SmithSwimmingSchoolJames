namespace SmithSwimmingSchoolJames.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public int CourseId { get; set; } 
        public virtual Course Course { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartTime { get; set; }
        public int AvailableSpots { get; set; }
        public int CoachId { get; set; } 
        public virtual Coach Coach { get; set; } 
        public virtual ICollection<Enrollment>? Enrollments { get; set; }
    }
}
