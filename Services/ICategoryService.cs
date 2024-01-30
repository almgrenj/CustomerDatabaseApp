using CustomerDatabaseApp.Entities;
using System.Collections.Generic;

namespace CustomerDatabaseApp.Services
{
    public interface ICategoryService
    {
        void AddCategory(CategoryEntity category);
        CategoryEntity GetCategory(int id);
        void UpdateCategory(CategoryEntity category);
        void DeleteCategory(int id);
        IEnumerable<CategoryEntity> GetAllCategories();
    }
}
