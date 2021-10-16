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
    public class CompanyManager : ICompanyService
    {
        DatabaseContext _databaseContext;

        public CompanyManager(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Add(Company entity)
        {
            _databaseContext.Database.ExecuteSqlRaw($"sp_AddCompany{entity.CompanyName},{entity.CompanyMail},{entity.CompanyPhone},{entity.CompanyFax},{entity.CompanyTaxNo},{entity.CompanyLogo}");
        }

        public void Delete(Company entity)
        {
            _databaseContext.Database.ExecuteSqlRaw($"sp_DeleteCompany{entity.CompanyId}");
        }

        public Company Get(string name)
        {
            return _databaseContext.Companies.FromSqlRaw($"sp_GetCompany{name}").SingleOrDefault();
        }

        public List<Company> GetAll()
        {
            return _databaseContext.Companies.FromSqlRaw($"sp_GetAllCompanies").ToList();
        }

        public void Update(Company entity)
        {
            _databaseContext.Database.ExecuteSqlRaw($"sp_UpdateCompany{entity.CompanyId},{entity.CompanyName},{entity.CompanyMail},{entity.CompanyPhone},{entity.CompanyFax},{entity.CompanyTaxNo}");
        }
    }
}
