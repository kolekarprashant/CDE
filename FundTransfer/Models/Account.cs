using System;
using System.Collections.Generic;

namespace FundTransfer.Models
{
    public partial class Account
    {
        public long Id { get; set; }
        public string AccountNo { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Created { get; set; }
    }
}
