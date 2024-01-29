using CustomerDatabaseApp.Models;
using System.Collections.Generic;
using CustomerDatabaseApp.Services;


namespace CustomerDatabaseApp.Services
{
    public interface IOrderService
    {
        void AddOrder(Order order);
        Order GetOrder(int id);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);
        IEnumerable<Order> GetAllOrders();
    }
}
