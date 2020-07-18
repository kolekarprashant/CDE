using AccountService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.Repository
{
    public interface IAccountRepository
    {
        Account GetAccountBalance(string accountNumber);
    }
}
