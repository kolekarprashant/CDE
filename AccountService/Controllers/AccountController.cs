using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountService.Models;
using AccountService.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IAccountRepository repository;

        public AccountController(IAccountRepository _accountRepository)
        {
            repository = _accountRepository;
        }

        // GET: api/Account/5
        [HttpGet("{accountNumber}", Name = "Get"),MapToApiVersion("1.0")]
        public IActionResult Get(string accountNumber)
        {
            Account result = new Account();
            result = repository.GetAccountBalance(accountNumber);
            if (result == null)
            {
                return NotFound("Record not found");
            }
            return Ok(result);
           
        }

    }
}
