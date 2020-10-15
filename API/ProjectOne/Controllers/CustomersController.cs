using Microsoft.AspNetCore.Mvc;
using Models.Model;
using ProjectOne.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectOne.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomersServices _dataServices;

        public CustomersController(ICustomersServices dataServices)
        {
            _dataServices = dataServices;
        }

        // GET: api/<CustomersController>
        // This is to get details of all customers
        [HttpGet]
        public IActionResult Get()
        {
            var customers = _dataServices.GetAll();

            return Ok(customers);

        }

        //GET api/<CustomersController>/5
        // This is to get the customer details based on id
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var customer = _dataServices.GetById(id);

            return Ok(customer);
        }

        // GET api/<CustomersController>/name
        // This is to get the customer details based on name
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            var customer = _dataServices.GetByName(name);

            return Ok(customer);
        }

        // POST api/<CustomersController>
        // This is used for adding new cutomer in the db
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            var newRecord = _dataServices.AddCustomer(customer);

            return Created(newRecord.Id.ToString(), newRecord);
        }

        // PUT api/<CustomersController>/5
        // This is used for updating customer details
        [HttpPut()]
        public IActionResult Put([FromBody] Customer customer)
        {
            _dataServices.UpdateCustomer(customer);

            return Accepted("Customer details updated successfully");
        }

        // DELETE api/<CustomersController>/5
        // This is used to delete customer from database
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _dataServices.DeleteCustomer(id);

            return NoContent();
        }
    }
}
