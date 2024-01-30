using System.Collections.Generic;
using CustomerDatabaseApp.Services;
using CustomerDatabaseApp.Entities;


namespace CustomerDatabaseApp.Services
{
    public interface IOrderService
    {
        void AddOrder(OrderEntity order);
        OrderEntity GetOrder(int id);
        void UpdateOrder(OrderEntity order);
        void DeleteOrder(int id);
        IEnumerable<OrderEntity> GetAllOrders();
    }
}
