using CustomerDatabaseApp.Models;
using CustomerDatabaseApp.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly CustomerDbContext _context;

    public OrderItemRepository(CustomerDbContext context)
    {
        _context = context;
    }

    public OrderItem GetById(int id) => _context.OrderItems.Find(id);

    public IEnumerable<OrderItem> GetAll() => _context.OrderItems.ToList();

    public void Add(OrderItem orderItem)
    {
        _context.OrderItems.Add(orderItem);
        _context.SaveChanges();
    }

    public void Update(OrderItem orderItem)
    {
        _context.OrderItems.Update(orderItem);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var orderItem = _context.OrderItems.Find(id);
        if (orderItem != null)
        {
            _context.OrderItems.Remove(orderItem);
            _context.SaveChanges();
        }
    }
}
