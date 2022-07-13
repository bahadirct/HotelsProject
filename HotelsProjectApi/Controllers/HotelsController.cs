using Business.Abstract;
using Business.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _hotelService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public  IActionResult GetById([FromQuery(Name = "id")] int id)
        {
            var result =  _hotelService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbystar")]
        public IActionResult GetByStar([FromQuery(Name = "star")] int star)
        {
            var result =  _hotelService.GetAllByStar(star);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("GetDbFile")]
        public String Post(IFormFile file) 
        {
            return file.FileName;
        }
      
    }
}
