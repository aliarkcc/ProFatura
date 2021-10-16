using Microsoft.EntityFrameworkCore;
using ProFatura.Entity.Concrete;
using ProFatura.Entity.Context;
using ProFatura.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFatura.Service.Concrete
{
    public class CategoryManager : ICategoryService
    {
        DatabaseContext _databaseContext;

        public CategoryManager(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public Category Get(string name)
        {
            return _databaseContext.Categories.FromSqlRaw($"sp_GetCategory {name}").SingleOrDefault();
        }

        public List<Category> GetAll()
        {
            return _databaseContext.Categories.FromSqlRaw($"sp_GetAllCategory").ToList();
        }
        public void Add(Category entity)
        {
            _databaseContext.Database.ExecuteSqlRaw($"sp_AddCategory {entity.CategoryName}");
        }

        public void Delete(Category entity)
        {
            _databaseContext.Database.ExecuteSqlRaw($"sp_DeleteCategory {entity.CategoryId}");
            _databaseContext.Categories.ToList();
        }

        public void Update(Category entity)
        {
            _databaseContext.Database.ExecuteSqlRaw($"sp_UpdateCategory {entity.CategoryId},{entity.CategoryName}");
        }
    }
}
