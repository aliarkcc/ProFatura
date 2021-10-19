using ProFatura.Entity.Concrete;
using ProFatura.Entity.Context;
using ProFatura.Service.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ProFatura.Service.Concrete
{
    public class ProductManager : IProductService
    {
        DatabaseContext _databaseContext;

        public ProductManager(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Add(Product entity)
        {
            _databaseContext.Database.ExecuteSqlRaw("exec [dbo].[sp_AddProduct] @name='"+entity.ProductName+"',@unitprice='"+entity.UnitPrice+"',@tax='"+entity.Tax+"',@description='"+entity.PDescription+"'");
        }

        public void Delete(int id)
        {
            _databaseContext.Database.ExecuteSqlRaw($"sp_DeleteProduct{id}");
        }

        public List<Product> Get(string name)
        {
            return _databaseContext.Products.FromSqlRaw($"sp_GetProduct{name}").FirstOrDefault();
        }

        public List<Product> Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _databaseContext.Products.FromSqlRaw($"sp_GetAllProducts").ToList();
        }

        public void Update(Product entity)
        {
            _databaseContext.Database.ExecuteSqlRaw($"sp_UpdateProduct{entity.ProductId},{entity.ProductName},{entity.UnitPrice},{entity.Tax},{entity.PDescription}");
        }
    }
}
