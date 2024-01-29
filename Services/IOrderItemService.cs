using CustomerDatabaseApp.Models;
using System.Collections.Generic;

namespace CustomerDatabaseApp.Services
{
    public interface IOrderItemService
    {
        void AddOrderItem(OrderItem orderItem);
        OrderItem GetOrderItem(int id);
        void UpdateOrderItem(OrderItem orderItem);
        void DeleteOrderItem(int id);
        IEnumerable<OrderItem> GetAllOrderItems();
    }
}
