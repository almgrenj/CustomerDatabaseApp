using CustomerDatabaseApp.Entities;
using System.Collections.Generic;

namespace CustomerDatabaseApp.Repositories.Interfaces
{

    public interface IProductRepository
{
    ProductEntity GetById(int id);
    IEnumerable<ProductEntity> GetAll();
    void Add(ProductEntity product);
    void Update(ProductEntity product);
    void Delete(int id);
}
}