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
        public DbSet<CostUnitsModel> CostUnit { get; set; }
        public DbSet<SalesOrderModel> SalesOrder { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeModel>().HasKey(e => e.EmployeeID);
            modelBuilder.Entity<CostUnitsModel>().HasKey(e => e.ReferenceID);
            modelBuilder.Entity<SalesOrderModel>().HasKey(e => e.SalesOrderKey);

        }
    }
}
