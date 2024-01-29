using CustomerDatabaseApp.Models;
using CustomerDatabaseApp.Services;
using CustomerDatabaseApp.Repositories.Interfaces; 
using System.Collections.Generic;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void AddProduct(Product product)
    {
     
        _productRepository.Add(product);
    }

    public Product GetProduct(int id)
    {
     
        return _productRepository.GetById(id);
    }

    public void UpdateProduct(Product product)
    {
      
        _productRepository.Update(product);
    }

    public void DeleteProduct(int id)
    {
       
        _productRepository.Delete(id);
    }

    public IEnumerable<Product> GetAllProducts()
    {
        
        return _productRepository.GetAll();
    }
}
