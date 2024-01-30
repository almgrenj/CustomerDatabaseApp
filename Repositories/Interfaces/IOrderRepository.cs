using CustomerDatabaseApp.Entities;
using System.Collections.Generic;

namespace CustomerDatabaseApp.Repositories.Interfaces
{

    public interface IOrderRepository
{
    OrderEntity GetById(int id);
    IEnumerable<OrderEntity> GetAll();
    void Add(OrderEntity order);
    void Update(OrderEntity order);
    void Delete(int id);
}
}