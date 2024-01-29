using CustomerDatabaseApp.Models;
using CustomerDatabaseApp.Repositories.Interfaces;
using CustomerDatabaseApp.Services;
using System.Collections.Generic;

public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _supplierRepository;

    public SupplierService(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public void AddSupplier(Supplier supplier)
    {
        _supplierRepository.Add(supplier);
    }

    public Supplier GetSupplier(int id)
    {
        return _supplierRepository.GetById(id);
    }

    public void UpdateSupplier(Supplier supplier)
    {
        _supplierRepository.Update(supplier);
    }

    public void DeleteSupplier(int id)
    {
        _supplierRepository.Delete(id);
    }

    public IEnumerable<Supplier> GetAllSuppliers()
    {
        return _supplierRepository.GetAll();
    }
}
