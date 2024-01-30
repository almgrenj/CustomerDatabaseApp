using CustomerDatabaseApp.Entities;
using CustomerDatabaseApp.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly DataContext _context;

    public OrderItemRepository(DataContext context)
    {
        _context = context;
    }

    public OrderItemEntity GetById(int id) => _context.OrderItems.Find(id);

    public IEnumerable<OrderItemEntity> GetAll() => _context.OrderItems.ToList();

    public void Add(OrderItemEntity orderItem)
    {
        _context.OrderItems.Add(orderItem);
        _context.SaveChanges();
    }

    public void Update(OrderItemEntity orderItem)
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
