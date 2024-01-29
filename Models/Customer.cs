using System.ComponentModel.DataAnnotations;

namespace CustomerDatabaseApp.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string? Address { get; set; } 

        [MaxLength(50)]
        public string? Phone { get; set; }   

        [MaxLength(100)]
        public string? Email { get; set; }   
    }
}
