//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web.Http.Description;
//using CompupharmLtd.Model;
//using CompupharmLtd.Service;
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
//        [ResponseType(typeof(ContactListResponse))]

//        public ContactListResponse Get(string status)
//        {
//            ContactListResponse productList;
//            productList = ContactService.GetAllMessages(status);
//            return productList;

//        }

//        // GET api/<ContactController>/5
//        [HttpGet]
//        [Route("MessageByID")]
//        [ResponseType(typeof(ContactResponse))]
//        public ContactResponse GetProduct(int id)
//        {
//            ContactResponse product;
//            product = ContactService.GetMessageByID(id);
//            return product;

//        }

//        // POST api/<ProductController>
//        [HttpPost]
//        [Route("CreateMessage")]
//        [ResponseType(typeof(ContactResponse))]

//        public ContactResponse Post(Contact product)
//        {
//            ContactResponse products;
//            products = ContactService.CreateMessage(product);
//            return products;
//        }

//        // PUT api/<ProductController>/5
//        [HttpPut]
//        [Route("EditMessage")]
//        [ResponseType(typeof(ContactResponse))]
//        public ContactResponse Put(int id, [FromBody] Contact value)
//        {

//            ContactResponse product;
//            product = ContactService.EditMessage(value);
//            return product;
//        }

//        // DELETE api/<ProductController>/5
//        [HttpDelete]
//        [Route("DeleteMessage")]
//        [ResponseType(typeof(ContactResponse))]

//        public ContactResponse Delete(int id)
//        {
//            ContactResponse product;
//            product = ContactService.DeleteMessage(id);
//            return product;
//        }
//    }
//}
