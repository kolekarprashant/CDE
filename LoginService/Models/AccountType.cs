using System;
using System.Collections.Generic;

namespace LoginService.Models
{
    public partial class AccountType
    {
        public AccountType()
        {
            Customer = new HashSet<Customer>();
        }

        public int AccTypeId { get; set; }
        public string AccTypeName { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
