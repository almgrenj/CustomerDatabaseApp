using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomerDatabaseApp.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }

        public List<Product> Products { get; set; }
    }
}
