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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Get()
        {
            Response executiveList;
            executiveList = ExecutiveService.GetAllExecutive();
            if (executiveList.status == "01")
            {
                NotFound();
            }
            return Ok( executiveList);

        }

        // GET api/<ProductController>/5
        [HttpGet]
        [Route("ExecutiveByID")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetExecutive(int id)
        {
            if (id == 0)
            {
                return BadRequest("id cannot be empty or 0");
            }
            Response executive;
            executive = ExecutiveService.GetExecutiveByID(id);
            if (executive.status == "01")
            {
                NotFound();
            }
            return Ok(executive);

        }

        // POST api/<ProductController>
        [HttpPost]
        [Route("CreateExecutive")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(ExecutiveRequest product)
        {
            Response executive;
            executive = ExecutiveService.CreateExecutive(product);
            if (executive.status == "01")
            {
                NotFound();
            }
            return Ok(executive);
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        [Route("EditExecutive")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] ExecutiveEditRequest value)
        {
            if (value.ExecutiveID == 0)
            {
                return BadRequest("id cannot be empty or 0");
            }
            Response executive;
            executive = ExecutiveService.EditExecutive(value);
            if (executive.status == "01")
            {
                NotFound("couldnt edit data");
            }
            return Ok(executive);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete]
        [Route("DeleteExecutive")]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest("id cannot be empty or 0");
            }
            Response executive;
            executive = ExecutiveService.DeleteExecutive(id);
            if (executive.status == "01")
            {
                NotFound();
            }
            return Ok(executive);
        }
    }
}
