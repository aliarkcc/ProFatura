﻿using Microsoft.EntityFrameworkCore;
using ProFatura.Entity.Concrete;
using ProFatura.Entity.Context;
using ProFatura.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFatura.Service.Concrete
{
    public class SupplierManager : ISupplierService
    {
        DatabaseContext _databaseContext;

        public SupplierManager(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Add(Supplier entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Supplier entity)
        {
            throw new NotImplementedException();
        }

        public Supplier Get(string name)
        {
            throw new NotImplementedException();
        }

        public List<Supplier> GetAll()
        {
            return _databaseContext.Suppliers.FromSqlRaw($"sp_GetAllSuppliers").ToList();
        }

        public void Update(Supplier entity)
        {
            throw new NotImplementedException();
        }
    }
}
