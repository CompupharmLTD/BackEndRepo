using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using CompupharmLtd.Model;
using CompupharmLtd.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompupharmLtd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        // GET: api/<ContactController>
        [HttpGet]
        [Route("MessageList")]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Get()
        {
            Response contactList;
            contactList = ContactService.GetAllMessages();
            if (contactList.status == "01")
            {
                NotFound();
            }
            return Ok(contactList);

        }

        // GET api/<ContactController>/5
        [HttpGet]
        [Route("MessageByID")]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetProduct(string id)
        {
            if (string.IsNullOrEmpty(id))
            {

                return NotFound("Id cannot be empty");

            }
            Response contact;
            contact = ContactService.GetMessageByID(id);
            if (contact.status == "01")
            {
                NotFound();
            }
            return Ok(contact);
        }

        // POST api/<ProductController>
        [HttpPost]
        [Route("CreateMessage")]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(ContactRequest product)
        {
            Response contact;
            contact = ContactService.CreateMessage(product);
            if (contact.status == "01")
            {
                NotFound();
            }
            return Ok(contact);
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        [Route("EditMessage")]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put( [FromBody] Contact value)
        {
            if ( string.IsNullOrEmpty(value.ticketID))
            {

                return NotFound("Id cannot be empty");

            }

            Response contact;
            contact = ContactService.EditMessage(value);
            if (contact.status == "01")
            {
                NotFound();
            }
            return Ok(contact);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete]
        [Route("DeleteMessage")]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {

                return NotFound("Id cannot be empty");

            }
            Response contact;
            contact = ContactService.DeleteMessage(id);
            if (contact.status == "01")
            {
                NotFound();
            }
            return Ok(contact);
        }
    }
}
