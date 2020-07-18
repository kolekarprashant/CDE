using System;
using System.Collections.Generic;

namespace AccountService.Models
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
