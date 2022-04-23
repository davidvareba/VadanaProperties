using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VadanaProperties.Repositories;
using VadanaProperties.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VadanaProperties.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        // GET: api/<ListingsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ListingsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ListingsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ListingsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ListingsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
