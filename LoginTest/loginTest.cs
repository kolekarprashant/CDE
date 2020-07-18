using LoginService.Controllers;
using System;
using Xunit;
using Moq;
using LoginService.Repository;
using System.Collections.Generic;
using LoginService.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginTest
{
    public class loginTest
    {
        LoginController controller;
        Mock<ILoginRepository> repository = new Mock<ILoginRepository>();
        List<Customer> customers = new List<Customer>();
        Login login = new Login();
        List<Login> logins = new List<Login>();
        LoginResponse response = new LoginResponse();

        public loginTest()
        {
            response.CustId = 1;
            response.CustName = "customer3";
            response.IsAdmin = true;
            response.IsFirstLogin = true;

            repository.Setup(x => x.getLogin(It.IsAny<Login>())).Returns(response);
            repository.Setup(x => x.changePassword(It.IsAny<Password>())).Returns(true);

            controller = new LoginController(repository.Object);

        }

        [Fact]
        public void GetLogin()
        {
            var result = controller.Post(new Login
            {
                CustName = "customer3",
                CustPassword = "pass123"
            });
            OkObjectResult actionresult = result as OkObjectResult;
            Assert.Equal(200, actionresult.StatusCode);

        }
        [Fact]
        public void GetLoginNotFound()
        {
            response = null;
            repository.Setup(x => x.getLogin(It.IsAny<Login>())).Returns(response);
            var result = controller.Post(new Login
            {
                CustName = "",
                CustPassword = "pass123"
            });
            NotFoundObjectResult actionresult = result as NotFoundObjectResult;
            Assert.Equal(404, actionresult.StatusCode);

        }

        [Fact]
        public void ChangePassword()
        {
            var result = controller.Put(new Password
            {
               CustId = 1,
               NewCustPassword ="pass123",
               OldCustPassword ="Pass1234"
            });
            OkObjectResult actionresult = result as OkObjectResult;
            Assert.Equal(200, actionresult.StatusCode);

        }
    }
}
