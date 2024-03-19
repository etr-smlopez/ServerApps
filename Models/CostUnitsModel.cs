using System.ComponentModel.DataAnnotations;

namespace ServerApp.Models
{
    public class CostUnitsModel
    {
        [Key]
        public int ReferenceID { get; set; }
        public string Type { get; set; } 
    }
}
