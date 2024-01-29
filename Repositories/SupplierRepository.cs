using CustomerDatabaseApp.Models;
using CustomerDatabaseApp.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

public class SupplierRepository : ISupplierRepository
{
    private readonly CustomerDbContext _context;

    public SupplierRepository(CustomerDbContext context)
    {
        _context = context;
    }

    public Supplier GetById(int id) => _context.Suppliers.Find(id);

    public IEnumerable<Supplier> GetAll() => _context.Suppliers.ToList();

    public void Add(Supplier supplier)
    {
        _context.Suppliers.Add(supplier);
        _context.SaveChanges();
    }

    public void Update(Supplier supplier)
    {
        _context.Suppliers.Update(supplier);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var supplier = _context.Suppliers.Find(id);
        if (supplier != null)
        {
            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();
        }
    }
}
