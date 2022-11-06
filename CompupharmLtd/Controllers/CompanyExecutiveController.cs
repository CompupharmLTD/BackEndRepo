using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using CompupharmLtd.Model;
using CompupharmLtd.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompupharmLtd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyExecutiveController : ControllerBase
    {
        [HttpGet]
        [Route("ExecutiveList")]
        [ResponseType(typeof(ExecutiveListResponse))]

        public ExecutiveListResponse Get()
        {
            ExecutiveListResponse executiveList;
            executiveList = ExecutiveService.GetAllExecutive();
            return executiveList;

        }

        // GET api/<ProductController>/5
        [HttpGet]
        [Route("ExecutiveByID")]
        [ResponseType(typeof(ExecutiveResponse))]
        public ExecutiveResponse GetExecutive(int id)
        {
            ExecutiveResponse executive;
            executive = ExecutiveService.GetExecutiveByID(id);
            return executive;

        }

        // POST api/<ProductController>
        [HttpPost]
        [Route("CreateExecutive")]
        [ResponseType(typeof(ExecutiveResponse))]

        public ExecutiveResponse Post(ExecutiveRequest product)
        {
            ExecutiveResponse executive;
            executive = ExecutiveService.CreateExecutive(product);
            return executive;
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        [Route("EditExecutive")]
        [ResponseType(typeof(ExecutiveResponse))]
        public ExecutiveResponse Put([FromBody] ExecutiveEditRequest value)
        {

            ExecutiveResponse executive;
            executive = ExecutiveService.EditExecutive(value);
            return executive;
        }

        // DELETE api/<ProductController>/5
        [HttpDelete]
        [Route("DeleteExecutive")]
        [ResponseType(typeof(ExecutiveResponse))]

        public ExecutiveResponse Delete(int id)
        {
            ExecutiveResponse executive;
            executive = ExecutiveService.DeleteExecutive(id);
            return executive;
        }
    }
}
