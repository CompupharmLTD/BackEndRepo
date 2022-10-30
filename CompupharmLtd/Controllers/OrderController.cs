using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using CompupharmLtd.Model;
using CompupharmLtd.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompupharmLtd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        // GET: api/<OrderController>
        [HttpGet]
        [Route("OrderList")]
        [ResponseType(typeof(OrderListResponse))]

        public OrderListResponse Get(string status)
        {
            OrderListResponse productList;
            productList = OrderService.GetAllOrders(status);
            return productList;

        }

        // GET api/<OrderController>/5
        [HttpGet]
        [Route("OrderByID")]
        [ResponseType(typeof(OrderResponse))]
        public OrderResponse GetOrdert(int id)
        {
            OrderResponse product;
            product = OrderService.GetOrderByID(id);
            return product;

        }

        // POST api/<OrderController>
        [HttpPost]
        [Route("CreateOrder")]
        [ResponseType(typeof(OrderResponse))]

        public OrderResponse Post(Order product)
        {
            OrderResponse products;
            products = OrderService.CreateOrder(product);
            return products;
        }

        // PUT api/<OrderController>/5
        [HttpPut]
        [Route("EditOrder")]
        [ResponseType(typeof(OrderResponse))]
        public OrderResponse Put(int id, [FromBody] Order value)
        {

            OrderResponse product;
            product = OrderService.EditOrder(value);
            return product;
        }
        // PUT api/<OrderController>/5
        [HttpPut]
        [Route("AuthorizeOrder")]
        [ResponseType(typeof(OrderResponse))]
        public OrderResponse AuthorizeOrder(int id, [FromBody] Order value)
        {

            OrderResponse product;
            product = OrderService.AuthoriseOrder(value);
            return product;
        }

        // DELETE api/<OrderController>/5
        [HttpDelete]
        [Route("DeleteOrder")]
        [ResponseType(typeof(OrderResponse))]

        public OrderResponse Delete(int id)
        {
            OrderResponse product;
            product = OrderService.DeleteOrder(id);
            return product;
        }
    }
}
