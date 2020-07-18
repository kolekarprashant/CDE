using System;
using System.Collections.Generic;

namespace FundTransfer.Models
{
    public partial class Country
    {
        public Country()
        {
            Customer = new HashSet<Customer>();
        }

        public int ContId { get; set; }
        public string ContName { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
