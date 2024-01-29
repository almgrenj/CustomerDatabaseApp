using System.ComponentModel.DataAnnotations;

namespace CustomerDatabaseApp.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string? Address { get; set; } 

        public string? ContactNumber { get; set; } 
    }
}
