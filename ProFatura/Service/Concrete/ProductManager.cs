using ProFatura.Entity.Concrete;
using ProFatura.Entity.Context;
using ProFatura.Service.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public void Delete(Product entity)
        {
            _databaseContext.Database.ExecuteSqlRaw($"sp_DeleteProduct{entity.ProductId}");
        }

        public Product Get(string name)
        {
            return _databaseContext.Products.FromSqlRaw($"sp_GetProduct{name}").FirstOrDefault();
        }

        public List<Product> GetAll()
        {
            return _databaseContext.Products.FromSqlRaw($"sp_GetAllProducts").ToList();
        }

        public void Update(Product entity)
        {
            _databaseContext.Database.ExecuteSqlRaw($"sp_UpdateProduct{entity.ProductId},{entity.ProductName},{entity.UnitPrice},{entity.Tax},{entity.PDescription}");
        }
    }
}
