using CustomerDatabaseApp.Models;
using CustomerDatabaseApp.Services;


namespace CustomerDatabaseApp.Services
{
    public interface ICustomerService
    {
        void AddCustomer(Customer customer);
        Customer GetCustomer(int id);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
        IEnumerable<Customer> GetAllCustomers();
    }
}
