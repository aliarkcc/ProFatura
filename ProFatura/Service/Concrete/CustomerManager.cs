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
    public class CustomerManager : ICustomerService
    {
        DatabaseContext _databaseContext = null;

        public CustomerManager(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Delete(Customer customer)
        {
            _databaseContext.Database.ExecuteSqlRaw($"sp_DeleteCustomers{customer.CustomerName}");
            _databaseContext.Customers.ToList();
        }

        public void Update(Customer customer)
        {
            _databaseContext.Customers.FromSqlRaw($"sp_UpdateCustomers {customer.CustomerId},{customer.CustomerName},{customer.CustomerSurname},{customer.CustomerNumber}," +
                $"{customer.CustomerMail},{customer.CustomerRegisterDate}");
            _databaseContext.Customers.ToList();
        }

        public Customer Get(string name)
        {
            var customer=_databaseContext.Customers.FromSqlRaw($"sp_GetCustomer {name}");
            return customer.SingleOrDefault();
        }

        public void Add(Customer c)
        {
            c.CustomerRegisterDate = DateTime.Now.ToString();
            _databaseContext.Database.ExecuteSqlRaw("exec [dbo].[sp_AddCustomers] @name='"+c.CustomerName+"',@surname='"+c.CustomerSurname+"',@number='"+c.CustomerNumber+"',@mail='"+c.CustomerMail+"',@rgstrdate='"+c.CustomerRegisterDate+"'");
        }

        public List<Customer> GetAll()
        {
            return _databaseContext.Customers.FromSqlRaw($"sp_GetAllCustomers").ToList();
        }
    }
}
