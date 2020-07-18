using AccountService.Controllers;
using System;
using Xunit;
using Moq;
using AccountService.Repository;
using System.Collections.Generic;
using AccountService.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccountTest
{
   public class accountTest
    {
        AccountController controller;
        Mock<IAccountRepository> repository = new Mock<IAccountRepository>();
        List<Account> account = new List<Account>();

        public accountTest() {

            account.Add(new Account
            {
                 Id = 1,
                 AccountNo = "100",
                 Amount = 2000,
                 Created = DateTime.Now

            });
            account.Add(new Account
            {
                Id = 2,
                AccountNo = "200",
                Amount = 3000,
                Created = DateTime.Now

            });
            account.Add(new Account
            {
                Id =31,
                AccountNo = "300",
                Amount = 6000,
                Created = DateTime.Now

            });

            repository.Setup(x => x.GetAccountBalance(It.IsAny<string>())).Returns((string acc) => account.Find(x => x.AccountNo == acc));

            controller = new AccountController(repository.Object);

        }

        [Fact]
        public void GetAccountBalance()
        {
            IActionResult account = controller.Get("300");
            OkObjectResult actionresult = account as OkObjectResult;
            Assert.Equal(200, actionresult.StatusCode);
        }

        [Fact]
        public void GetAccountBalanceNotFound()
        {
            IActionResult account = controller.Get("500");
            NotFoundObjectResult actionresult = account as NotFoundObjectResult;
            Assert.Equal(404, actionresult.StatusCode);
        }
    }
}
