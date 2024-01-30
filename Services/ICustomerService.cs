using CustomerDatabaseApp.Entities;
using CustomerDatabaseApp.Services;


namespace CustomerDatabaseApp.Services
{
    public interface ICustomerService
    {
        void AddCustomer(CustomerEntity customer);
        CustomerEntity GetCustomer(int id);
        void UpdateCustomer(CustomerEntity customer);
        void DeleteCustomer(int id);
        IEnumerable<CustomerEntity> GetAllCustomers();
    }
}
