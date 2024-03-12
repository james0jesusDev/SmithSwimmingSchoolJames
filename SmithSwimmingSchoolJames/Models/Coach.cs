using System.Text.RegularExpressions;

namespace SmithSwimmingSchoolJames.Models
{
    public class Coach
    {
        public int CoachId { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        
        public virtual ICollection<Group>? Groups { get; set; } 
        public virtual ICollection<ProgressReport>? ProgressReports { get; set; }
    }
}
