using System.ComponentModel.DataAnnotations;

namespace ServerApp.Models
{
    public class SalesOrderModel
    {
        [Key]
        public int SalesOrderKey { get; set; }
        public int SO_Status { get; set; }
        public string SO_SONumber { get; set; }
        public DateTime SO_SODate { get; set; }
        public int CreatedBy { get; set; }
    }
}
