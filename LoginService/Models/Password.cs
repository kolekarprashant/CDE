using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Models
{
    public class Password
    {
        public long CustId { get; set; }
        public string OldCustPassword { get; set; }
        public string NewCustPassword { get; set; }
    }
}
