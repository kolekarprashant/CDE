using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundTransfer.Repository;
using FundTransfer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FundTransfer.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BenificiaryController : ControllerBase
    {
        IFundTransferRepository repository;

        public BenificiaryController(IFundTransferRepository _fundTransferRepository)
        {
            repository = _fundTransferRepository;
        }
       

        // POST: api/Benificiary
        [HttpPost, MapToApiVersion("1.0")]
        public IActionResult Post([FromBody] AddBenificiary model)
        {
            var result = repository.AddBenificiary(model);
            if (!result)
            {
                return NotFound("Benificiary not added");
            }
            return Ok(result);
           
        }

      
    }
}
