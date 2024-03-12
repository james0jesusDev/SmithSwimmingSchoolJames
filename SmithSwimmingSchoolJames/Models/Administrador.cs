using System.ComponentModel.DataAnnotations;

namespace SmithSwimmingSchoolJames.Models
{
    public class Administrador
    {
        [Key]
        public int AdministratorId { get; set; }
        public string? Administradorname { get; set; }
        public string? Email { get; set; }

        public string? AdministradorUser { get; set; }


    }
}
