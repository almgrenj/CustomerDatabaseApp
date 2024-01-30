using CustomerDatabaseApp.Entities;
using System.Collections.Generic;

namespace CustomerDatabaseApp.Services
{
    public interface ISupplierService
    {
        void AddSupplier(SupplierEntity supplier);
        SupplierEntity GetSupplier(int id);
        void UpdateSupplier(SupplierEntity supplier);
        void DeleteSupplier(int id);
        IEnumerable<SupplierEntity> GetAllSuppliers();
    }
}
