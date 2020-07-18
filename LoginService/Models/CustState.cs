using System;
using System.Collections.Generic;

namespace LoginService.Models
{
    public partial class CustState
    {
        public CustState()
        {
            Customer = new HashSet<Customer>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
