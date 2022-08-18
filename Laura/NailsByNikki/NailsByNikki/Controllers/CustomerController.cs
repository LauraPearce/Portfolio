using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NailsByNikki.Models;
using NailsByNikki.Repositories;

namespace NailsByNikki.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository repository)
        {
            _customerRepository = repository;
        }
        //TODO: add the create customer as an endpoint
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Customer>> GetAll()
        {
            return Ok(_customerRepository.GetAll());
        }

        [HttpGet("GetById")]
        public ActionResult<Customer> GetById(int id)
        {
            Customer customer = _customerRepository.GetById(id);

            if (customer is not null)
            {
                return Ok(customer);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPatch("Update")]
        public IActionResult Update(Customer updatedCustomerDetails)
        {
            Customer customer = _customerRepository.GetById(updatedCustomerDetails.CustomerId);

            if (customer is not null)
            {
                _customerRepository.Update(updatedCustomerDetails);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            Customer customer = _customerRepository.GetById(id);

            if (customer is not null)
            {
                _customerRepository.Delete(customer);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        
        [HttpPost("Create")]
        public IActionResult Create(Customer newCustomer)
        {
            if (newCustomer.CustomerId >= 0
                && newCustomer.FirstName is not null
                && newCustomer.Surname is not null
                && newCustomer.Email is not null
                && newCustomer.PhoneNumber is not null
                && newCustomer.Allergies is not null
                && newCustomer.Medication is not null
                )
            {
                _customerRepository.Create(newCustomer);
                return CreatedAtAction(nameof(Create), new { id = newCustomer.CustomerId }, newCustomer);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
