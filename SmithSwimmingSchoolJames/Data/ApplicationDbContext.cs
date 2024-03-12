using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmithSwimmingSchoolJames.Models;

namespace SmithSwimmingSchoolJames.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet <Administrador> Administradors  { get; set; }
        public DbSet <Coach> Coachs  { get; set; }
        public DbSet <Course> Courses  { get; set; }
        public DbSet <Group> Groups  { get; set; }
        public DbSet <Instructor> Instructors  { get; set; }
        public DbSet <Student> Students  { get; set; }
        public DbSet <Enrollment> Enrollments  { get; set; }
        public DbSet <ProgressReport> ProgressReports  { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
