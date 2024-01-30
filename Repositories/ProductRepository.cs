using CustomerDatabaseApp.Entities;
using CustomerDatabaseApp.Repositories.Interfaces;
using System.Collections.Generic;
public class ProductRepository : IProductRepository
{
    private readonly DataContext _context;

    public ProductRepository(DataContext context)
    {
        _context = context;
    }

    public ProductEntity GetById(int id) => _context.Products.Find(id);

    public IEnumerable<ProductEntity> GetAll() => _context.Products.ToList();

    public void Add(ProductEntity product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void Update(ProductEntity product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var product = _context.Products.Find(id);
        if (product != null)
        {
            
            var orderItems = _context.OrderItems.Where(oi => oi.ProductId == id);
            _context.OrderItems.RemoveRange(orderItems);

           
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }

}
