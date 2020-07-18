using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginService.Models;
using LoginService.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginService.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        ILoginRepository repository;

        public LoginController(ILoginRepository _loginRepository)
        {
            repository = _loginRepository;
        }


        // POST: api/Login
        [HttpPost]
        [MapToApiVersion("1.0")]
        public IActionResult Post([FromBody] Login model)
        {
            LoginResponse result = new LoginResponse();
            result = repository.getLogin(model);
            if (result == null)
            {
                return NotFound("Record not found");
            }
            return Ok(result);

        }

        // PUT: api/Login/5
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public IActionResult Put([FromBody] Password model)
        {
            var result = repository.changePassword(model);
            if (!result)
            {
                return NotFound("password not changed");
            }
            return Ok(result);

        }


    }
}
