using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerDatabaseApp.Entities
{
    public class ProductEntity
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public string? Description { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        public CategoryEntity Category { get; set; }
    }
}
