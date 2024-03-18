using System.ComponentModel.DataAnnotations;

namespace ServerApp.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
