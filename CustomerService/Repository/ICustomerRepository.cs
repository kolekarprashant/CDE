using CustomerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.Repository
{
    public interface ICustomerRepository
    {
        bool AddCustomer(Customer model);
        bool DeleteCustomer(int id);
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(int id);
        bool UpdateCustomer(int id, Customer model);
        LoginResponse getLogin(Login model);
        bool changePassword(Password model);


    }
}
