using Microsoft.AspNetCore.Mvc;
using WebAppDemo.DTOs;
using WebAppDemo.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StringCreatorController : ControllerBase
    {
        // GET: api/<StringCreatorController>
        [HttpGet]
        public StringData Get()
        {
            return new StringData
            {
                Content = new StringGenerator().Generate()
            };
        }

        // GET api/<StringCreatorController>/5
        [HttpGet("{id}")]
        public StringData Get(int id)
        {
            return new StringData
            {
                Content = new StringGenerator(id).Generate()
            };
        }

        //// POST api/<StringCreatorController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<StringCreatorController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<StringCreatorController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
