using CustomerDatabaseApp.Entities;
using CustomerDatabaseApp.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

public class SupplierRepository : ISupplierRepository
{
    private readonly DataContext _context;

    public SupplierRepository(DataContext context)
    {
        _context = context;
    }

    public SupplierEntity GetById(int id) => _context.Suppliers.Find(id);

    public IEnumerable<SupplierEntity> GetAll() => _context.Suppliers.ToList();

    public void Add(SupplierEntity supplier)
    {
        _context.Suppliers.Add(supplier);
        _context.SaveChanges();
    }

    public void Update(SupplierEntity supplier)
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
