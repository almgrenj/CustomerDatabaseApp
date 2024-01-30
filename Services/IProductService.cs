using CustomerDatabaseApp.Entities;
using System.Collections.Generic;

namespace CustomerDatabaseApp.Services
{
    public interface IProductService
    {
        void AddProduct(ProductEntity product);
        ProductEntity GetProduct(int id);
        void UpdateProduct(ProductEntity product);
        void DeleteProduct(int id);
        IEnumerable<ProductEntity> GetAllProducts();
    }
}
