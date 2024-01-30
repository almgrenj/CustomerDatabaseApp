using CustomerDatabaseApp.Entities;
using System.Collections.Generic;

namespace CustomerDatabaseApp.Repositories.Interfaces
{
    public interface ISupplierRepository
    {
        void Add(SupplierEntity supplier);
        SupplierEntity GetById(int id);
        void Update(SupplierEntity supplier);
        void Delete(int id);
        IEnumerable<SupplierEntity> GetAll();
    }
}
