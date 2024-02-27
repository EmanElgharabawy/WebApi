using Day1WebApi.Model.Resources;
using Microsoft.EntityFrameworkCore;

namespace Day1WebApi.Model.Database
{
    public class Studentdbcontext :DbContext
    {
        public Studentdbcontext( DbContextOptions<Studentdbcontext> option) :base (option)
        {
        }

        public DbSet<Student> Student { get; set; } 
        public DbSet<Department> Department { get; set; }
    }
}
