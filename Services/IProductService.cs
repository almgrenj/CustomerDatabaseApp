using CustomerDatabaseApp.Models;
using System.Collections.Generic;

namespace CustomerDatabaseApp.Services
{
    public interface IProductService
    {
        void AddProduct(Product product);
        Product GetProduct(int id);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        IEnumerable<Product> GetAllProducts();
    }
}
