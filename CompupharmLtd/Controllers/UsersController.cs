using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using CompupharmLtd.Model;
using CompupharmLtd.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompupharmLtd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //// GET: api/<UsersController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<UsersController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<UsersController>
        [HttpPost]
        [Route("Login")]

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Login( [FromBody] LoginUserRequest cred)
        {
            Response response =   UserService.Login(cred);
            return Ok(response);


        }
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] UserRequest customer)
        {
            Response response = UserService.Create(customer);
            return Ok(response);


        }
        [HttpPut]
        [Route("AccountValidation")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AccountValidation([FromQuery] string email)
        {
            Response response = UserService.ValidateAccount(email);
            return Ok( response);


        }

        //// PUT api/<UsersController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UsersController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
