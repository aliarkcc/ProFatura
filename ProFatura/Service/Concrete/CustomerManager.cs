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
    public class CustomerManager : ICustomerService
    {
        DatabaseContext _databaseContext = null;

        public CustomerManager(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Delete(int id)
        {
            _databaseContext.Database.ExecuteSqlRaw($"sp_DeleteCustomers{id}");
            _databaseContext.Customers.ToList();
        }

        public void Update(Customer customer)
        {
            _databaseContext.Customers.FromSqlRaw($"sp_UpdateCustomers {customer.CustomerId},{customer.CustomerName},{customer.CustomerSurname},{customer.CustomerNumber}," +
                $"{customer.CustomerMail},{customer.CustomerRegisterDate}");
            _databaseContext.Customers.ToList();
        }

        public List<Customer> Get(string name)
        {
            return _databaseContext.Customers.FromSqlRaw($"sp_GetCustomer {name}").ToList();
        }

        public void Add(Customer c)
        {
            c.CustomerRegisterDate = DateTime.Now.ToString();
            _databaseContext.Database.ExecuteSqlRaw("exec [dbo].[sp_AddCustomers] @name='"+c.CustomerName+"',@surname='"+c.CustomerSurname+"',@number='"+c.CustomerNumber+"',@mail='"+c.CustomerMail+"',@rgstrdate='"+c.CustomerRegisterDate+"'");
        }

        public List<Customer> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            return _databaseContext.Customers.FromSqlRaw($"sp_GetAllCustomers").ToList();
        }

        public List<Customer> Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
