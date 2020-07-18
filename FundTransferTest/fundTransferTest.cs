using FundTransfer.Controllers;
using System;
using Xunit;
using Moq;
using FundTransfer.Repository;
using System.Collections.Generic;
using FundTransfer.Models;
using Microsoft.AspNetCore.Mvc;

namespace FundTransferTest
{
   public class fundTransferTest
    {
        FundTransferController controller;
        BenificiaryController _controller;
        Mock<IFundTransferRepository> repository = new Mock<IFundTransferRepository>();
       
        public fundTransferTest()
        {
            controller = new FundTransferController(repository.Object);
            _controller = new BenificiaryController(repository.Object);
        }

        [Fact]
        public void AmountTransfer()
        {
            repository.Setup(x => x.AmountTransfer(It.IsAny<FundTransferRequest>())).Returns(true);
            var result = controller.Post(new FundTransferRequest
            {
                Amount = 200,
                BenAccountNo = "100",
                CustAccountNo ="101"
            });
            OkObjectResult actionresult = result as OkObjectResult;
            Assert.Equal(200, actionresult.StatusCode);


        }
        [Fact]
        public void AmountTransferNotFound()
        {
            repository.Setup(x => x.AmountTransfer(It.IsAny<FundTransferRequest>())).Returns(false);
            var result = controller.Post(new FundTransferRequest
            {
                Amount = 200,
                BenAccountNo = "",
                CustAccountNo = ""
            });
            
            NotFoundObjectResult actionresult = result as NotFoundObjectResult;
            Assert.Equal(404, actionresult.StatusCode);


        }

        [Fact]
        public void AddBenificiary()
        {
            repository.Setup(x => x.AddBenificiary(It.IsAny<AddBenificiary>())).Returns(true);
            var result = _controller.Post(new AddBenificiary
            {
               BenificiaryAccountNo ="200",
               BenificiaryName = "name1",
               cust_id = 1
            });
            OkObjectResult actionresult = result as OkObjectResult;
            Assert.Equal(200, actionresult.StatusCode);


        }
        [Fact]
        public void AddBenificiaryNotFound()
        {
            repository.Setup(x => x.AddBenificiary(It.IsAny<AddBenificiary>())).Returns(false);
            var result = _controller.Post(new AddBenificiary
            {
                BenificiaryAccountNo = "",
                BenificiaryName = "name1",
                cust_id = 0
            });
            NotFoundObjectResult actionresult = result as NotFoundObjectResult;
            Assert.Equal(404, actionresult.StatusCode);

        }

    }
}
