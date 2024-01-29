using CustomerDatabaseApp.Models;
using System.Collections.Generic;

namespace CustomerDatabaseApp.Repositories.Interfaces 
{

    public interface IProductRepository
{
    Product GetById(int id);
    IEnumerable<Product> GetAll();
    void Add(Product product);
    void Update(Product product);
    void Delete(int id);
}
}