using CustomerDatabaseApp.Entities;
using CustomerDatabaseApp.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

public class CategoryRepository : ICategoryRepository
{
    private readonly DataContext _context;

    public CategoryRepository(DataContext context)
    {
        _context = context;
    }

    public CategoryEntity GetById(int id) => _context.Categories.Find(id);

    public IEnumerable<CategoryEntity> GetAll() => _context.Categories.ToList();

    public void Add(CategoryEntity category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
    }

    public void Update(CategoryEntity category)
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
