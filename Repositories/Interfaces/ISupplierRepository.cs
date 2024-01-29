using CustomerDatabaseApp.Models;
using System.Collections.Generic;

namespace CustomerDatabaseApp.Repositories.Interfaces
{
    public interface ISupplierRepository
    {
        void Add(Supplier supplier);
        Supplier GetById(int id);
        void Update(Supplier supplier);
        void Delete(int id);
        IEnumerable<Supplier> GetAll();
    }
}
