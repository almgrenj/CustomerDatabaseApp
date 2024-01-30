using System.ComponentModel.DataAnnotations;

namespace CustomerDatabaseApp.Entities
{
    public class SupplierEntity
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
