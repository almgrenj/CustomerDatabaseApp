using CustomerDatabaseApp.Entities;
using CustomerDatabaseApp.Repositories.Interfaces;
using System.Collections.Generic;
public class OrderRepository : IOrderRepository
{
    private readonly DataContext _context;

    public OrderRepository(DataContext context)
    {
        _context = context;
    }

    public OrderEntity GetById(int id) => _context.Orders.Find(id);

    public IEnumerable<OrderEntity> GetAll() => _context.Orders.ToList();

    public void Add(OrderEntity order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
    }

    public void Update(OrderEntity order)
    {
        _context.Orders.Update(order);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var order = _context.Orders.Find(id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }
}
