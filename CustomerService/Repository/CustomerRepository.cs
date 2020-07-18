using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService.Models;

namespace CustomerService.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public bool AddCustomer(Customer model)
        {
            var dbcontext = new OnlinebankingContext();
            var customer = new Customer();
            var account = new Account();

            customer.CustId = model.CustId;
            customer.CustName = model.CustName;
            customer.CustUserName = model.CustUserName;
            customer.CustPassword = model.CustPassword;
            customer.CustAddress = model.CustAddress;
            customer.CustEmail = model.CustEmail;
            customer.Pan = model.Pan;
            customer.ContactNo = model.ContactNo;
            customer.InitialAmount = model.InitialAmount;
            customer.AccountNo = model.AccountNo;
            customer.Dob = model.Dob;
            customer.Created = DateTime.Now;
            customer.AccTypeId = model.AccTypeId;
            customer.ContId = model.ContId;
            customer.StateId = model.StateId;
            customer.IsAdmin = model.IsAdmin;
            dbcontext.Customer.Add(customer);
            dbcontext.SaveChanges();
            long cust_id = customer.CustId;
            if (cust_id > 0)
            {
                var accountData = dbcontext.Customer.FirstOrDefault(x => x.CustId == cust_id);
                account.AccountNo = accountData.AccountNo;
                account.Amount = accountData.InitialAmount;
                account.Created = DateTime.Now;
                dbcontext.Account.Add(account);
                dbcontext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteCustomer(int id)
        {
            var dbcontext = new OnlinebankingContext();

            var customer = dbcontext.Customer.FirstOrDefault(x => x.CustId == id);
            if(customer != null)
            {
                customer.Deleted = true;
                dbcontext.SaveChanges();
                return true;
            }
            return false;
        }

        public Customer GetCustomer(int id)
        {
            Customer objCustomer = null;

            var customer = new OnlinebankingContext().Customer.FirstOrDefault(x => x.CustId == id);

            if (customer != null)
            {
                objCustomer = new Customer()
                {
                    CustId = customer.CustId,
                    CustName = customer.CustName,
                    CustUserName = customer.CustUserName,
                    CustPassword = customer.CustPassword,
                    CustAddress = customer.CustAddress,
                    CustEmail = customer.CustEmail,
                    Pan = customer.Pan,
                    ContactNo = customer.ContactNo,
                    InitialAmount = customer.InitialAmount,
                    Dob = customer.Dob,
                    Created = customer.Created,
                    AccTypeId = customer.AccTypeId,
                    ContId = customer.ContId,
                    StateId = customer.StateId,
                    Deleted = customer.Deleted

                };
                var pAccountType = new OnlinebankingContext().AccountType.FirstOrDefault(e => e.AccTypeId == objCustomer.AccTypeId);
                if (pAccountType != null)
                {
                    objCustomer.AccType = new AccountType()
                    {
                        AccTypeId = pAccountType.AccTypeId,
                        AccTypeName = pAccountType.AccTypeName
                    };
                }
                var pState = new OnlinebankingContext().CustState.FirstOrDefault(e => e.StateId == objCustomer.StateId);
                if (pState != null)
                {
                    objCustomer.State = new CustState()
                    {
                        StateId = pState.StateId,
                        StateName = pState.StateName
                    };
                }
                var pCountry = new OnlinebankingContext().Country.FirstOrDefault(e => e.ContId == objCustomer.ContId);
                if (pCountry != null)
                {
                    objCustomer.Cont = new Country()
                    {
                        ContId = pCountry.ContId,
                        ContName = pCountry.ContName
                    };
                }

            }
            return objCustomer;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var listOfCustomers = new List<Customer>();
            var customers = new OnlinebankingContext().Customer;
            var accountTypes = new OnlinebankingContext().AccountType;
            var states = new OnlinebankingContext().CustState;
            var countries = new OnlinebankingContext().Country;

            Customer objCustomer = null;
            foreach (var customer in customers)
            {
                objCustomer = new Customer()
                {
                    CustId = customer.CustId,
                    CustName = customer.CustName,
                    CustUserName = customer.CustUserName,
                    CustPassword = customer.CustPassword,
                    CustAddress = customer.CustAddress,
                    CustEmail = customer.CustEmail,
                    Pan = customer.Pan,
                    ContactNo = customer.ContactNo,
                    InitialAmount = customer.InitialAmount,
                    Dob = customer.Dob,
                    Created = customer.Created,
                    AccTypeId = customer.AccTypeId,
                    ContId = customer.ContId,
                    StateId = customer.StateId,
                    Deleted = customer.Deleted

                };
                var pAccountType = accountTypes.FirstOrDefault(e => e.AccTypeId == objCustomer.AccTypeId);
                if (pAccountType != null)
                {
                    objCustomer.AccType = new AccountType()
                    {
                        AccTypeId = pAccountType.AccTypeId,
                        AccTypeName = pAccountType.AccTypeName
                    };
                }
                var pState = states.FirstOrDefault(e => e.StateId == objCustomer.StateId);
                if (pState != null)
                {
                    objCustomer.State = new CustState()
                    {
                        StateId = pState.StateId,
                        StateName = pState.StateName
                    };
                }
                var pCountry = countries.FirstOrDefault(e => e.ContId == objCustomer.ContId);
                if (pCountry != null)
                {
                    objCustomer.Cont = new Country()
                    {
                        ContId = pCountry.ContId,
                        ContName = pCountry.ContName
                    };
                }

                listOfCustomers.Add(objCustomer);
            }
            return listOfCustomers;
        }

        public bool UpdateCustomer(int id, Customer model)
        {
            var dbcontext = new OnlinebankingContext();

            var customer = dbcontext.Customer.FirstOrDefault(x => x.CustId == id);
            if(customer != null)
            {
               
                customer.CustName = model.CustName;
                customer.CustUserName = model.CustUserName;
                customer.CustPassword = model.CustPassword;
                customer.CustAddress = model.CustAddress;
                customer.CustEmail = model.CustEmail;
                customer.Pan = model.Pan;
                customer.ContactNo = model.ContactNo;
                customer.InitialAmount = model.InitialAmount;
                customer.Dob = model.Dob;
                customer.Created = DateTime.Now;
                customer.AccTypeId = model.AccTypeId;
                customer.ContId = model.ContId;
                customer.StateId = model.StateId;

                dbcontext.SaveChanges();
                return true;

            }
            return false;
        }

        public LoginResponse getLogin(Login model)
        {
            var dbcontext = new OnlinebankingContext();
            LoginResponse obj = new LoginResponse();
            obj = dbcontext.Customer.Where(x => x.CustUserName == model.CustName && x.CustPassword == model.CustPassword)
                    .Select(x => new LoginResponse
                    {
                        CustName = x.CustUserName,
                        IsAdmin = x.IsAdmin,
                        IsFirstLogin = x.IsFirstLogin,
                        CustId = x.CustId
                    }).Single();
           if(obj != null)
            {
               if(obj.IsFirstLogin == null)
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
        public bool changePassword(Password model) {
            var dbcontext = new OnlinebankingContext();

            if(model != null)
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
