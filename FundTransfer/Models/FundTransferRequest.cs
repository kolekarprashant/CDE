using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundTransfer.Models
{
    public class FundTransferRequest
    {
        public string CustAccountNo { get; set; }
        public string BenAccountNo { get; set; }
        public decimal Amount { get; set; }

    }
}
