using ProFatura.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFatura.Entity.Concrete
{
    public class Product:IEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int Tax { get; set; }
        public string PDescription { get; set; }
    }
}
