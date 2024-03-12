namespace SmithSwimmingSchoolJames.Models
{
    public class ProgressReport
    {
        public int ProgressReportId { get; set; }
        public int CoachId { get; set; } 
        public virtual Coach? Coach { get; set; } 
        public int StudentId { get; set; }
        public virtual Student? Student { get; set; } 
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
