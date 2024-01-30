using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomerDatabaseApp.Entities
{
    public class CategoryEntity
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }

        public List<ProductEntity> Products { get; set; }
    }
}
