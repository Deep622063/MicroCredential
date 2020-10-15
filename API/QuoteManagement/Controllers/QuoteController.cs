using Microsoft.AspNetCore.Mvc;
using Models.Model;
using QuoteManagement.Services;

namespace QuoteManagement.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/quote")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private IQuoteServices _dataServices;

        public QuoteController(IQuoteServices dataServices)
        {
            _dataServices = dataServices;
        }

        // GET: api/<QuoteController>
        // This is to get details of all Quote
        [HttpGet]
        public IActionResult Get()
        {
            var quotes = _dataServices.GetAll();
           
            return Ok(quotes);
        }

        //GET api/<QuoteController>/5
        // This is to get the Quote details based on id
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var quote = _dataServices.GetById(id);

            return Ok(quote);
        }

        // POST api/<QuotesController>
        // This is used for adding new quote in the db
        [HttpPost]
        public IActionResult Post([FromBody] Quote quote)
        {
            var newRecord = _dataServices.Add(quote);

            return Created(newRecord.Id.ToString(), newRecord);
        }

        // PUT api/<QuoteController>/5
        // This is used for updating quote details
        [HttpPut()]
        public IActionResult Put([FromBody] Quote quote)
        {
            _dataServices.Update(quote);

            return Accepted("Quote details updated successfully");
        }

        // DELETE api/<QuoteController>/5
        // This is used to delete quote from database
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _dataServices.Delete(id);

            return NoContent();
        }
    }
}
