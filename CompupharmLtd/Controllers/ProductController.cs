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
    public class ProductController : ControllerBase
    {
        // GET: api/<ProductController>
        [HttpGet]
        [Route("ProductList")]
        [ResponseType(typeof(ProductListResponse))]

        public ProductListResponse Get(string status)
        {
            ProductListResponse productList;
            productList = ProductService.GetAllProduct(status);
            return productList;

            }

        // GET api/<ProductController>/5
        [HttpGet]
        [Route("ProductByID")]
        [ResponseType(typeof(ProductResponse))]
        public ProductResponse GetProduct(int id)
        {
            ProductResponse product;
            product = ProductService.GetProductByID(id);
            return product;

        }

        // POST api/<ProductController>
        [HttpPost]
        [Route("CreateProduct")]
        [ResponseType(typeof(ProductResponse))]

        public ProductResponse Post(Product product)
        {
            ProductResponse products;
            products = ProductService.CreateProduct(product);
            return products;
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        [Route("EditProduct")]
        [ResponseType(typeof(ProductResponse))]
        public ProductResponse Put(int id, [FromBody] Product value)
        {

            ProductResponse product;
            product = ProductService.EditProduct(value);
            return product;
        }

        // DELETE api/<ProductController>/5
        [HttpDelete]
        [Route("DeleteProduct")]
        [ResponseType(typeof(ProductResponse))]

        public ProductResponse Delete(int id)
        {
            ProductResponse product;
            product = ProductService.DeleteProduct(id);
            return product;
        }
    }
}
