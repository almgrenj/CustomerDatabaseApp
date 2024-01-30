using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerDatabaseApp.Entities
{
    public class OrderItemEntity
    {
        [Key]
        public int OrderItemId { get; set; }

        [ForeignKey("Order")]
        public int? OrderId { get; set; }

        public OrderEntity Order { get; set; }

        [ForeignKey("Product")]
        public int? ProductId { get; set; }

        public ProductEntity Product { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }
    }
}
