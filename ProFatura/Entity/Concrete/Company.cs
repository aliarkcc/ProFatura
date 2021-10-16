using ProFatura.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFatura.Entity.Concrete
{
    public class Company:IEntity
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyMail { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyFax { get; set; }
        public string CompanyTaxNo { get; set; }
        public string CompanyLogo { get; set; }
    }
}
