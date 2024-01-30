using CustomerDatabaseApp.Entities;
using CustomerDatabaseApp.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

public class CustomerRepository : ICustomerRepository
{
    private readonly DataContext _context;

    public CustomerRepository(DataContext context)
    {
        _context = context;
    }

    public CustomerEntity GetById(int id)
    {
        var customerEntity = _context.Customers.Find(id);
        if (customerEntity != null)
        {
            return new CustomerEntity
            {
                CustomerId = customerEntity.CustomerId,
                Name = customerEntity.Name,
                Address = customerEntity.Address ?? string.Empty,
                Phone = customerEntity.Phone ?? string.Empty,
                Email = customerEntity.Email ?? string.Empty
            };
        }

        throw new InvalidOperationException($"Customer with ID {id} not found.");
    }




    public IEnumerable<CustomerEntity> GetAll()
    {
        return _context.Customers
               .Select(c => new CustomerEntity
               {
                   CustomerId = c.CustomerId,
                   Name = c.Name,
                   Address = c.Address ?? string.Empty, 
                   Phone = c.Phone ?? string.Empty,     
                   Email = c.Email ?? string.Empty      
               })
               .ToList();
    }

    public void Add(CustomerEntity customer)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();
    }

    public void Update(CustomerEntity customer)
    {
        var existingCustomer = _context.Customers.Find(customer.CustomerId);
        if (existingCustomer != null)
        {
            _context.Entry(existingCustomer).CurrentValues.SetValues(customer);
            _context.SaveChanges();
        }
        else
        {
            throw new InvalidOperationException($"Customer with ID {customer.CustomerId} not found.");
        }
    }


    public void Delete(int id)
    {
        var customer = _context.Customers.Find(id);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
