using CustomerDatabaseApp.Entities;
using System.Collections.Generic;

namespace CustomerDatabaseApp.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        void Add(CustomerEntity customer);
        CustomerEntity GetById(int id);
        void Update(CustomerEntity customer);
        void Delete(int id);
        IEnumerable<CustomerEntity> GetAll();
    }
}

