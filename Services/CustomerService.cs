using CustomerDatabaseApp.Entities;
using CustomerDatabaseApp.Repositories.Interfaces;
using CustomerDatabaseApp.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public void AddCustomer(CustomerEntity customer)
    {
        _customerRepository.Add(customer);
    }

    public CustomerEntity GetCustomer(int id)
    {
        return _customerRepository.GetById(id);
    }

    public void UpdateCustomer(CustomerEntity customer)
    {
        _customerRepository.Update(customer);
    }

    public void DeleteCustomer(int id)
    {
        _customerRepository.Delete(id);
    }

    public IEnumerable<CustomerEntity> GetAllCustomers()
    {
        return _customerRepository.GetAll();
    }
}
