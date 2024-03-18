using Microsoft.EntityFrameworkCore;
using ServerApp.Models;

namespace ServerApp.SQLAccess
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<EmployeeModel> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeModel>().HasKey(e => e.EmployeeID);

        }
    }
}
