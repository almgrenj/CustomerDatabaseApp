using CustomerDatabaseApp.Entities;
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

    public void AddCategory(CategoryEntity category)
    {
        _categoryRepository.Add(category);
    }

    public CategoryEntity GetCategory(int id)
    {
        return _categoryRepository.GetById(id);
    }

    public void UpdateCategory(CategoryEntity category)
    {
        _categoryRepository.Update(category);
    }

    public void DeleteCategory(int id)
    {
        _categoryRepository.Delete(id);
    }

    public IEnumerable<CategoryEntity> GetAllCategories()
    {
        return _categoryRepository.GetAll();
    }
}
