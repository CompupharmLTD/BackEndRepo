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

namespace CompupharmLtd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutletsController : ControllerBase
    {
        [HttpGet]
        [Route("OutletList")]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Get()
        {
            Response outletList;
            outletList = OutletService.GetAllOutlet();
            if (outletList.statusCode == 1)
            {
                NotFound();
            }
            return Ok( outletList);

        }

        // GET api/<ProductController>/5
        [HttpGet]
        [Route("OutletByID")]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetExecutive(int id)
        {
            Response outlet;
            if (id == 0)
            {
                return BadRequest("Id cannot be 0");
            }
            outlet = OutletService.GetOutletByID(id);
            if (outlet.statusCode == 1)
            {
                return NotFound();
            }
            return Ok( outlet);

        }

        // POST api/<ProductController>
        [HttpPost]
        [Route("CreateOutlet")]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Post(OutletRequest Coutlet)
        {
            if (!UtilityService.IsPhoneNbr(Coutlet.PhoneNumber) && !UtilityService.IsValidEmail(Coutlet.Email))
            {
                return BadRequest("phone number and email invalid");
            }

            Response outlet;
            outlet = OutletService.CreateOutlet(Coutlet);
            if (outlet.statusCode == 1)
            {
                return NotFound();
            }
            return Ok(outlet);
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        [Route("EditOutlet")]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] OutletEditRequest value)
        {
            if (value.OutletID == 0)
            {
                return BadRequest("Id cannot be 0");
            }
            if (!UtilityService.IsPhoneNbr(value.PhoneNumber) && !UtilityService.IsValidEmail(value.Email))
            {
                return BadRequest("phone number and email invalid");
            }


            Response outletResponse;
            outletResponse = OutletService.EditOutlet(value);
            if(outletResponse.statusCode== 1)
            {
                return BadRequest("Something happened, try again");
            }
            return Ok(outletResponse);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete]
        [Route("DeleteOutlet")]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id cannot be 0");
            }

            Response outletResponse; 
            outletResponse = OutletService.DeleteOutlet(id);
            if (outletResponse.statusCode== 1)
            {
              return  BadRequest("Couldnt delete");
            }
            return Ok(outletResponse);
        }
    }
}
