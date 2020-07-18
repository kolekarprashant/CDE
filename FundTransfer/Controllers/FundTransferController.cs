using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundTransfer.Models;
using FundTransfer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FundTransfer.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class FundTransferController : ControllerBase
    {
        IFundTransferRepository repository;

        public FundTransferController(IFundTransferRepository _fundTransferRepository)
        {
            repository = _fundTransferRepository;
        }

       
        // POST: api/FundTransfer
        [HttpPost, MapToApiVersion("1.0")]
        public IActionResult Post([FromBody] FundTransferRequest model)
        {
            var result = repository.AmountTransfer(model);
            if (!result)
            {
                return NotFound("Error in Amount transfer");
            }
            return Ok(result);
             
        }

       
    }
}
