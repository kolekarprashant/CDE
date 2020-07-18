using System;
using System.Collections.Generic;

namespace FundTransfer.Models
{
    public partial class Benificiary
    {
        public long Id { get; set; }
        public long? CustId { get; set; }
        public long? BenId { get; set; }

        public virtual Customer Ben { get; set; }
        public virtual Customer Cust { get; set; }
    }
}
