using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ServerApp.Models;
using System.Data;

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
        public List<CostUnitsModel> GetDataFromSqlView()
        {
            var costUnit = new List<CostUnitsModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("SELECT ReferenceID,Type FROM vwCostUnits", connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        costUnit.Add(new CostUnitsModel
                        {
                            ReferenceID = reader.GetInt32(reader.GetOrdinal("ReferenceID")),
                            Type = reader.GetString(reader.GetOrdinal("Type"))
                        });
                      
                    } 
                }
            }

            return costUnit;
        }

        public List<SalesOrderModel> GetDataSalesOrder()
        {
            var salesorder = new List<SalesOrderModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("SELECT SalesOrderKey, SO_Status, SO_SONumber, SO_SODate, CreatedBy FROM DashboardSalesOrder", connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        salesorder.Add(new SalesOrderModel
                        {
                            SalesOrderKey = reader.GetInt32(reader.GetOrdinal("SalesOrderKey")),
                            SO_Status = reader.GetInt32(reader.GetOrdinal("SO_Status")),
                            SO_SONumber = reader.GetString(reader.GetOrdinal("SO_SONumber")),
                            SO_SODate = reader.GetDateTime(reader.GetOrdinal("SO_SODate")),
                            CreatedBy = reader.GetInt32(reader.GetOrdinal("CreatedBy"))
                         });
                       
                    } 
                }
            }

            return salesorder;
        }
       
    }
}
