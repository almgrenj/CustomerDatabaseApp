using CustomerDatabaseApp.Models;
using System.Collections.Generic;

namespace CustomerDatabaseApp.Services
{
    public interface ICategoryService
    {
        void AddCategory(Category category);
        Category GetCategory(int id);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
        IEnumerable<Category> GetAllCategories();
    }
}
