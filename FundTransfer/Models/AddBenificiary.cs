using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundTransfer.Models
{
    public class AddBenificiary
    {
        public string BenificiaryName { get; set; }
        public string BenificiaryAccountNo { get; set; }
        public long cust_id { get; set; }
    }
}
