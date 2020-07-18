using CustomerService.Controllers;
using System;
using Xunit;
using Moq;
using CustomerService.Repository;
using System.Collections.Generic;
using CustomerService.Models;

namespace customerServiceTest
{
    public class CustomerTest
    {
        CustomerController controller;
        Mock<ICustomerRepository> repository = new Mock<ICustomerRepository>();
        List<Customer> customers = new List<Customer>();
        public CustomerTest()
        {
            customers.Add(new Customer
            {
                CustId = 1,
                CustName = "customer1",
                CustUserName = "cust1",
                CustPassword = "pass123",
                CustAddress = "pune",
                CustEmail = "c@gmail.com",
                Pan = "pan12345",
                ContactNo = "9766543345",
                InitialAmount = 200,
                Dob = DateTime.Now,
                Created = DateTime.Now,
                AccTypeId = 1,
                ContId = 1,
                StateId = 1,
                IsFirstLogin = true,
                IsAdmin = false,
                AccountNo = "101"
            });
            customers.Add(new Customer
            {
                CustId = 2,
                CustName = "customer2",
                CustUserName = "cust2",
                CustPassword = "pass123",
                CustAddress = "pune",
                CustEmail = "c@gmail.com",
                Pan = "pan12345",
                ContactNo = "9766543345",
                InitialAmount = 200,
                Dob = DateTime.Now,
                Created = DateTime.Now,
                AccTypeId = 1,
                ContId = 1,
                StateId = 1,
                IsFirstLogin = true,
                IsAdmin = false,
                AccountNo = "101"
            });
            customers.Add(new Customer
            {
                CustId = 3,
                CustName = "customer3",
                CustUserName = "cust3",
                CustPassword = "pass123",
                CustAddress = "pune",
                CustEmail = "c@gmail.com",
                Pan = "pan12345",
                ContactNo = "9766543345",
                InitialAmount = 200,
                Dob = DateTime.Now,
                Created = DateTime.Now,
                AccTypeId = 1,
                ContId = 1,
                StateId = 1,
                IsFirstLogin = true,
                IsAdmin = false,
                AccountNo = "101"
            });
            repository.Setup(x => x.GetCustomers()).Returns(() => customers);
            //repository.Setup(x => x.GetTask(It.IsAny<int>())).Returns((int id) => tasks.Find(x => x.Task_ID == id));
            //repository.Setup(x => x.AddTask(It.IsAny<Tasks>())).Callback((Tasks task) => tasks.Add(task));

        }

        [Fact]
        public void Test1()
        {

        }
    }
}
