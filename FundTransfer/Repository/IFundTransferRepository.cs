using FundTransfer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundTransfer.Repository
{
    public interface IFundTransferRepository
    {
        bool AddBenificiary(AddBenificiary model);

        bool AmountTransfer(FundTransferRequest model);
    }
}
