using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Models
{
    public class LoginResponse
    {
        public long CustId { get; set; }
        public string CustName { get; set; }
        public bool? IsFirstLogin { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
