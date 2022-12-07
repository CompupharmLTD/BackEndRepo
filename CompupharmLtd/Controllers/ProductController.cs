using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using System.Web.Http.Description;
using System.Web.Http.Results;
using CompupharmLtd.Model;
using CompupharmLtd.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompupharmLtd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: api/<ProductController>
        [HttpGet]
        [Route("ProductList")]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]

        public IActionResult Get(string status)
        {
            if (status ==null||status== string.Empty)
            {
              return  BadRequest("status cannot be empty");
            }else if(status.ToLower() != "all" && status.ToLower() != "active" && status.ToLower() != "inactive")
            {
                return BadRequest("invalid status value");

            }
            Response productList;
            productList = ProductService.GetAllProduct(status);
            return Ok( productList);

            }

        // GET api/<ProductController>/5
        [HttpGet]
        [Route("ProductByID")]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        public IActionResult GetProduct(int id)
        {
            if (id == 0)
            {
                return BadRequest("id cannot be empty or 0");
            }
            Response product;
            product = ProductService.GetProductByID(id);
            if (product.statusCode == 1)
            {
                return NotFound("No product with that ID");
            }
            return Ok(product);

        }

        // POST api/<ProductController>
        [HttpPost]
        [Route("CreateProduct")]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(ProductRequest product)
        {
            bool productValid = ProductService.ValidateProductRequest( product);

            Response products;
            if (!productValid)
            {
                return BadRequest("Please check input and try again");
            }
            products = ProductService.CreateProduct(product);
            if (products.statusCode == 1)
            {
                return BadRequest("try again");                                                                                                                                                  ; 
            }
            return Ok(products);
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        [Route("EditProduct")]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put( [FromBody] ProductEditRequest value)
        {
           // bool productValid = ProductService.ValidateProductEditRequest(value);
            if (value.ProductID==0)
            {
                return BadRequest("Please check input and try again");

            }

            Response product;
            product = ProductService.EditProduct(value);
            if (product.statusCode == 1)
            {
                return BadRequest("try again"); ;

            }
            return Ok(product);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete]
        [Route("DeleteProduct")]      
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest("id cannot be empty or 0");
            }
            Response product;
            product = ProductService.DeleteProduct(id);
            return Ok( product);
        }
    }
}
