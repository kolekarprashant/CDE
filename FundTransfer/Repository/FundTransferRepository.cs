using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundTransfer.Models;

namespace FundTransfer.Repository
{
    public class FundTransferRepository : IFundTransferRepository
    {
        public bool AddBenificiary(AddBenificiary model)
        {
            var dbcontext = new OnlinebankingContext();
            var customer = new OnlinebankingContext().Customer.FirstOrDefault(x => x.AccountNo == model.BenificiaryAccountNo);
            var benificiary = new Benificiary();
            if(customer != null)
            {
                benificiary.CustId = model.cust_id;
                benificiary.BenId = customer.CustId;
                dbcontext.Benificiary.Add(benificiary);
                dbcontext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool AmountTransfer(FundTransferRequest model)
        {
            var dbcontext = new OnlinebankingContext();
            var amountTransfer = new AmountTransfer();
            AmountTransfer objAmt = new AmountTransfer();
            var Frmbalance = new OnlinebankingContext().Account.Where(x => x.AccountNo == model.CustAccountNo).OrderByDescending(x => x.Created.Value).Select(x => x.Amount).FirstOrDefault();
            if(Frmbalance < model.Amount || Frmbalance < 0 || Frmbalance == null)
            {
                return false;
            }
            else
            {
                var Tobalance = new OnlinebankingContext().Account.Where(x => x.AccountNo == model.BenAccountNo).OrderByDescending(x => x.Created.Value).Select(x => x.Amount).FirstOrDefault();
                decimal FromAccountBalance = Convert.ToDecimal(Frmbalance) - Convert.ToDecimal(model.Amount);
                decimal ToAccountBalance = Convert.ToDecimal(Tobalance) + Convert.ToDecimal(model.Amount);

                objAmt.FromAccount = model.CustAccountNo;
                objAmt.ToAccount = model.BenAccountNo;
                objAmt.Amount = model.Amount;
                objAmt.Created = DateTime.Now;
                dbcontext.AmountTransfer.Add(objAmt);
                int id = dbcontext.SaveChanges();
                if(id > 0)
                {
                    Account obj = new Account();
                    obj.AccountNo = model.CustAccountNo;
                    obj.Amount = FromAccountBalance;
                    obj.Created = DateTime.Now;
                    dbcontext.Account.Add(obj);
                   int frmid = dbcontext.SaveChanges();
                    if(frmid > 0)
                    {
                        Account obj1 = new Account();
                        obj1.AccountNo = model.BenAccountNo;
                        obj1.Amount = ToAccountBalance;
                        obj1.Created = DateTime.Now;
                        dbcontext.Account.Add(obj1);
                        dbcontext.SaveChanges();

                    }

                    return true;
                }
              
            }
            return false ;
        }
    }
}
