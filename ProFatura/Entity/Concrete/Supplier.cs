using ProFatura.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFatura.Entity.Concrete
{
    public class Supplier:IEntity
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierMail { get; set; }
        public string SupplierPhone { get; set; }
        public string SupplierFax { get; set; }
        public string SupplierTaxNo { get; set; }

    }
}
