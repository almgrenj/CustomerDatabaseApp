using CustomerDatabaseApp.Entities;
using System.Collections.Generic;

namespace CustomerDatabaseApp.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        void Add(CategoryEntity category);
        CategoryEntity GetById(int id);
        void Update(CategoryEntity category);
        void Delete(int id);
        IEnumerable<CategoryEntity> GetAll();
    }
}
