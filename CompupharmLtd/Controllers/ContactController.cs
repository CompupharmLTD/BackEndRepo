//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace CompupharmLtd.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ContactController : ControllerBase
//    {
//        // GET: api/<ContactController>
//        [HttpGet]

//        [Route("MessageList")]

//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        // GET api/<ContactController>/5
//        [HttpGet("{id}")]
//        [Route("MessageByID")]

//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/<ContactController>
//        [HttpPost]
//        [Route("CreateMessage")]

//        public void Post([FromBody] string value)
//        {
//        }

//        // PUT api/<ContactController>/5
//        [HttpPut("{id}")]
//        [Route("EditMessage")]

//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE api/<ContactController>/5
//        [HttpDelete("{id}")]
//        [Route("DeleteMessage")]

//        public void Delete(int id)
//        {
//        }
//    }
//}
