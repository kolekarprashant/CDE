using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginService.Models;

namespace LoginService.Repository
{
    public class LoginRepository : ILoginRepository
    {
        public LoginResponse getLogin(Login model)
        {
            var dbcontext = new OnlinebankingContext();
            LoginResponse obj = new LoginResponse();
            if(model.CustName == "" || model.CustName == null || model.CustPassword == "" || model.CustPassword == null)
            {
                return null;
            }
            obj = dbcontext.Customer.Where(x => x.CustUserName == model.CustName && x.CustPassword == model.CustPassword)
                    .Select(x => new LoginResponse
                    {
                        CustName = x.CustUserName,
                        IsAdmin = x.IsAdmin,
                        IsFirstLogin = x.IsFirstLogin,
                        CustId = x.CustId
                    }).Single();
            if (obj != null)
            {
                if (obj.IsFirstLogin == null)
                {
                    var customer = dbcontext.Customer.FirstOrDefault(x => x.CustId == obj.CustId);
                    if (customer != null)
                    {
                        customer.IsFirstLogin = true;
                        dbcontext.SaveChanges();
                    }
                }
            }
            return obj;

        }
        public bool changePassword(Password model)
        {
            var dbcontext = new OnlinebankingContext();

            if (model != null)
            {
                var customer = dbcontext.Customer.FirstOrDefault(x => x.CustId == model.CustId);
                if (customer != null)
                {
                    customer.CustPassword = model.NewCustPassword;
                    dbcontext.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
