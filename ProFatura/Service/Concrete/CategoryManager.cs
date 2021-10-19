using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProFatura.Entity.Concrete;
using ProFatura.Entity.Context;
using ProFatura.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public List<Category> Get(string name)
        {
            return _databaseContext.Categories.FromSqlRaw($"sp_GetCategory {name}").ToList();
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            if (filter == null)

            {
                return _databaseContext.Categories.FromSqlRaw($"sp_GetAllCategory").ToList();

            }
            else
            {
               return _databaseContext.Categories.FromSqlRaw($"sp_GetAllCategoryid{filter}").ToList();
            }
        }
        public void Add(Category entity)
        {
            _databaseContext.Database.ExecuteSqlRaw($"sp_AddCategory {entity.CategoryName}");
        }

        public void Delete(int id)
        {
            _databaseContext.Database.ExecuteSqlRaw($"sp_DeleteCategory {id}");
            _databaseContext.Categories.ToList();
        }

        public void Update(Category entity)
        {
            _databaseContext.Database.ExecuteSqlRaw($"sp_UpdateCategory {entity.CategoryId},{entity.CategoryName}");
        }

        public List<Category> Get(int id)
        {
            return  _databaseContext.Categories.FromSqlRaw($"exec sp_GetAllCategoryid {id}").ToList();
        }

    }
}
