using CustomerDatabaseApp.Entities;
using System.Collections.Generic;

namespace CustomerDatabaseApp.Repositories.Interfaces
{
    public interface IOrderItemRepository
    {
        void Add(OrderItemEntity orderItem);
        OrderItemEntity GetById(int id);
        void Update(OrderItemEntity orderItem);
        void Delete(int id);
        IEnumerable<OrderItemEntity> GetAll();
    }
}
