using CustomerDatabaseApp.Models;
using CustomerDatabaseApp.Repositories.Interfaces;
using CustomerDatabaseApp.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public void AddCustomer(Customer customer)
    {
        _customerRepository.Add(customer);
    }

    public Customer GetCustomer(int id)
    {
        return _customerRepository.GetById(id);
    }

    public void UpdateCustomer(Customer customer)
    {
        _customerRepository.Update(customer);
    }

    public void DeleteCustomer(int id)
    {
        _customerRepository.Delete(id);
    }

    public IEnumerable<Customer> GetAllCustomers()
    {
        return _customerRepository.GetAll();
    }
}
