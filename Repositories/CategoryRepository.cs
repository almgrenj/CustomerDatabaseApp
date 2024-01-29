using CustomerDatabaseApp.Models;
using CustomerDatabaseApp.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

public class CategoryRepository : ICategoryRepository
{
    private readonly CustomerDbContext _context;

    public CategoryRepository(CustomerDbContext context)
    {
        _context = context;
    }

    public Category GetById(int id) => _context.Categories.Find(id);

    public IEnumerable<Category> GetAll() => _context.Categories.ToList();

    public void Add(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
    }

    public void Update(Category category)
    {
        _context.Categories.Update(category);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var category = _context.Categories.Find(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
