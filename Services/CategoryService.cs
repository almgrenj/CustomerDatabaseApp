using CustomerDatabaseApp.Models;
using CustomerDatabaseApp.Repositories.Interfaces;
using CustomerDatabaseApp.Services;
using System.Collections.Generic;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public void AddCategory(Category category)
    {
        _categoryRepository.Add(category);
    }

    public Category GetCategory(int id)
    {
        return _categoryRepository.GetById(id);
    }

    public void UpdateCategory(Category category)
    {
        _categoryRepository.Update(category);
    }

    public void DeleteCategory(int id)
    {
        _categoryRepository.Delete(id);
    }

    public IEnumerable<Category> GetAllCategories()
    {
        return _categoryRepository.GetAll();
    }
}
