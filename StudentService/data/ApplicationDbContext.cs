using Microsoft.EntityFrameworkCore;
using StudentService.database.db.models;

namespace StudentService.database.db.config
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        //public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         optionsBuilder.UseMySQL("server=localhost;database=studentdb;user=root;password=root");
        }

    }
}
