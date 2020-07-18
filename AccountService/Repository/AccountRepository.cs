using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountService.Models;

namespace AccountService.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public Account GetAccountBalance(string accountNumber)
        {
            var dbcontext = new OnlinebankingContext();
            Account obj = new Account();
            obj = dbcontext.Account.Where(x => x.AccountNo == accountNumber)
                 .Select(x => new Account
                 {
                     Id = x.Id,
                     AccountNo = x.AccountNo,
                     Amount = x.Amount                  
                 }).OrderByDescending(x => x.Created).FirstOrDefault();

            return obj;
        }
    }
}
