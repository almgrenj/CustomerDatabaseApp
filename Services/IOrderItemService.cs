using CustomerDatabaseApp.Entities;
using System.Collections.Generic;

namespace CustomerDatabaseApp.Services
{
    public interface IOrderItemService
    {
        void AddOrderItem(OrderItemEntity orderItem);
        OrderItemEntity GetOrderItem(int id);
        void UpdateOrderItem(OrderItemEntity orderItem);
        void DeleteOrderItem(int id);
        IEnumerable<OrderItemEntity> GetAllOrderItems();
    }
}
