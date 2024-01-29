using CustomerDatabaseApp.Models;
using System.Collections.Generic;

namespace CustomerDatabaseApp.Repositories.Interfaces
{
    public interface IOrderItemRepository
    {
        void Add(OrderItem orderItem);
        OrderItem GetById(int id);
        void Update(OrderItem orderItem);
        void Delete(int id);
        IEnumerable<OrderItem> GetAll();
    }
}
