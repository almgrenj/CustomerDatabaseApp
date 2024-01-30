using CustomerDatabaseApp.Entities;
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

    public void AddSupplier(SupplierEntity supplier)
    {
        _supplierRepository.Add(supplier);
    }

    public SupplierEntity GetSupplier(int id)
    {
        return _supplierRepository.GetById(id);
    }

    public void UpdateSupplier(SupplierEntity supplier)
    {
        _supplierRepository.Update(supplier);
    }

    public void DeleteSupplier(int id)
    {
        _supplierRepository.Delete(id);
    }

    public IEnumerable<SupplierEntity> GetAllSuppliers()
    {
        return _supplierRepository.GetAll();
    }
}
