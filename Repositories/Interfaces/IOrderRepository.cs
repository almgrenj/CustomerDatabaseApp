using CustomerDatabaseApp.Models;
using System.Collections.Generic;

namespace CustomerDatabaseApp.Repositories.Interfaces 
{

    public interface IOrderRepository
{
    Order GetById(int id);
    IEnumerable<Order> GetAll();
    void Add(Order order);
    void Update(Order order);
    void Delete(int id);
}
}