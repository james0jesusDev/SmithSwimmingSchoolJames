using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SmithSwimmingSchoolJames.Models
{
    public enum CursoNiveles
    {
        jovenes,avanzados, inicio, adultos, etc
    }



    public class Course
    {
        public int CourseId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Level { get; set; } 
        public virtual Coach? Coach { get; set; }
        public int InstructorId { get; set; }
        [DisplayFormat(NullDisplayText ="No grade")]
        public CursoNiveles? CursoNiveles { get; set; }
        public virtual Instructor? Instructor { get; set; } 
        public virtual ICollection<Group>? Groups { get; set; } 
    }
}
