using CustomerDatabaseApp.Models;
using CustomerDatabaseApp.Repositories.Interfaces; 
using System.Collections.Generic;
public class OrderRepository : IOrderRepository
{
    private readonly CustomerDbContext _context;

    public OrderRepository(CustomerDbContext context)
    {
        _context = context;
    }

    public Order GetById(int id) => _context.Orders.Find(id);

    public IEnumerable<Order> GetAll() => _context.Orders.ToList();

    public void Add(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
    }

    public void Update(Order order)
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
