using CustomerDatabaseApp.Models;
using System.Collections.Generic;

namespace CustomerDatabaseApp.Services
{
    public interface ISupplierService
    {
        void AddSupplier(Supplier supplier);
        Supplier GetSupplier(int id);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(int id);
        IEnumerable<Supplier> GetAllSuppliers();
    }
}
