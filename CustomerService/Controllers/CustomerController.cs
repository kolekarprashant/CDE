using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService.Models;
using CustomerService.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    [ApiVersion("1.0")]  
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerRepository repository;
      
        public CustomerController(ICustomerRepository _customerRepository) 
        {
            repository = _customerRepository;
        }

       
       
        [HttpGet]
        [MapToApiVersion("1.0")]
        public IActionResult Get()
        {
            var result = repository.GetCustomers();
            if (!result.Any())
            {
                return NotFound("Record not found");
            }
            return Ok(result);
           
        }

        [HttpGet("{id}", Name = "Get")]
        [MapToApiVersion("1.0")]
        public IActionResult Get(int id)
        {
            var result = repository.GetCustomer(id);
            if (result == null)
            {
                return NotFound("Record not found");
            }
            return Ok(result);
         
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        public IActionResult Post([FromBody] Customer model)
        {
            var result = repository.AddCustomer(model);
            if (!result)
            {
                return NotFound("Record not inserted");
            }
            return Ok(result);
           
        }

        
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public IActionResult Put(int id, [FromBody] Customer model)
        {
            var result = repository.UpdateCustomer(id, model);
            if (!result)
            {
                return NotFound("Record not updated");
            }
            return Ok(result);
           
        }

       
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public IActionResult Delete(int id)
        {
            var result = repository.DeleteCustomer(id);
            if (!result)
            {
                return NotFound("Record not deleted");
            }
            return Ok(result);
            
        }
    }
}
