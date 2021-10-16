using ProFatura.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProFatura.Entity.Concrete
{
    public class Customer:IEntity
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname{ get; set; }
        public string CustomerNumber { get; set; }
        public string CustomerMail { get; set; }
        public string CustomerRegisterDate { get; set; }
    }
}
