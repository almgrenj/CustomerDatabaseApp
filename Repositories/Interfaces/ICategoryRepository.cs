using CustomerDatabaseApp.Models;
using System.Collections.Generic;

namespace CustomerDatabaseApp.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        Category GetById(int id);
        void Update(Category category);
        void Delete(int id);
        IEnumerable<Category> GetAll();
    }
}
