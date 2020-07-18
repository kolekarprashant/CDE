using CustomerService.Controllers;
using System;
using Xunit;
using Moq;
using CustomerService.Repository;
using System.Collections.Generic;
using CustomerService.Models;
using Microsoft.AspNetCore.Mvc;

namespace customerTest
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
            repository.Setup(x => x.GetCustomer(It.IsAny<int>())).Returns((int id) => customers.Find(x => x.CustId == id));
            repository.Setup(x => x.AddCustomer(It.IsAny<Customer>())).Returns(true);

            controller = new CustomerController(repository.Object);
        }

        [Fact]
        public void GetCustomers()
        {
            IActionResult customers = controller.Get();
            OkObjectResult actionresult = customers as OkObjectResult;
            Assert.Equal(200, actionresult.StatusCode);

        }

        [Fact]
        public void GetCustomerNotFound()
        {
            
            IActionResult customers = controller.Get();
            customers = null;
            NotFoundObjectResult actionresult = customers as NotFoundObjectResult;
            Assert.Equal(404, actionresult.StatusCode);

        }

        [Fact]
        public void GetCustomerById()
        {
            IActionResult customers = controller.Get(1);
            OkObjectResult actionresult = customers as OkObjectResult;
            Assert.Equal(200, actionresult.StatusCode);

        }

        [Fact]
        public void GetCustomerByIdNotFound()
        {

            IActionResult customers = controller.Get(100);
            NotFoundObjectResult actionresult = customers as NotFoundObjectResult;
            Assert.Equal(404, actionresult.StatusCode);

        }

        [Fact]
        public void AddCustomer()
        {

          var result =  controller.Post(new Customer {
                CustId = 5,
                CustName = "customer4",
                CustUserName = "cust4",
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
                AccountNo = "109"
            });
            OkObjectResult actionresult = result as OkObjectResult;
            Assert.Equal(200, actionresult.StatusCode);

        }
    }
}