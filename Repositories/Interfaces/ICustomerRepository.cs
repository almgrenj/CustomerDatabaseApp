using CustomerDatabaseApp.Models;
using System.Collections.Generic;

namespace CustomerDatabaseApp.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        Customer GetById(int id);
        void Update(Customer customer);
        void Delete(int id);
        IEnumerable<Customer> GetAll();
    }
}

