using System;
using System.Collections.Generic;

namespace LoginService.Models
{
    public partial class AmountTransfer
    {
        public long Id { get; set; }
        public string FromAccount { get; set; }
        public string ToAccount { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Created { get; set; }
    }
}
