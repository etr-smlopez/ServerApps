using Microsoft.EntityFrameworkCore;
using ServerApp.Models;

namespace ServerApp.SQLAccess
{
    public class DataRepository
    {
        private readonly string _connectionString;

        public DataRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<EmployeeModel> GetDataFromSqlServer()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(_connectionString);

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                return context.Employees.ToList();
            }
        }
    }
}
