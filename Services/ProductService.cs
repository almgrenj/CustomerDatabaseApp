using CustomerDatabaseApp.Services;
using CustomerDatabaseApp.Repositories.Interfaces;
using System.Collections.Generic;
using CustomerDatabaseApp.Entities;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void AddProduct(ProductEntity product)
    {
     
        _productRepository.Add(product);
    }

    public ProductEntity GetProduct(int id)
    {
     
        return _productRepository.GetById(id);
    }

    public void UpdateProduct(ProductEntity product)
    {
      
        _productRepository.Update(product);
    }

    public void DeleteProduct(int id)
    {
       
        _productRepository.Delete(id);
    }

    public IEnumerable<ProductEntity> GetAllProducts()
    {
        
        return _productRepository.GetAll();
    }
}
