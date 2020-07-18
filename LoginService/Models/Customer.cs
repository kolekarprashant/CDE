using System;
using System.Collections.Generic;

namespace LoginService.Models
{
    public partial class Customer
    {
        public Customer()
        {
            BenificiaryBen = new HashSet<Benificiary>();
            BenificiaryCust = new HashSet<Benificiary>();
        }

        public long CustId { get; set; }
        public string CustName { get; set; }
        public string CustUserName { get; set; }
        public string CustPassword { get; set; }
        public string CustAddress { get; set; }
        public string CustEmail { get; set; }
        public string Pan { get; set; }
        public string ContactNo { get; set; }
        public decimal? InitialAmount { get; set; }
        public DateTime? Dob { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool? Deleted { get; set; }
        public int? AccTypeId { get; set; }
        public int? ContId { get; set; }
        public int? StateId { get; set; }
        public bool? IsFirstLogin { get; set; }
        public bool? IsAdmin { get; set; }
        public string AccountNo { get; set; }

        public virtual AccountType AccType { get; set; }
        public virtual Country Cont { get; set; }
        public virtual CustState State { get; set; }
        public virtual ICollection<Benificiary> BenificiaryBen { get; set; }
        public virtual ICollection<Benificiary> BenificiaryCust { get; set; }
    }
}
