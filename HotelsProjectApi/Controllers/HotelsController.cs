using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
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

        [HttpGet("getbyname")]
        public IActionResult GetByName([FromQuery(Name = "name")] string name)
        {
            var result = _hotelService.GetByName(name);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbystar")]
        public IActionResult GetByStar([FromQuery(Name = "star")] int star)
        {
            var result = _hotelService.GetAllByStar(star);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("uploadcsv")]
        public IActionResult UploadCsv(IFormFile file)
        {
            var result = _hotelService.GetDbFile(file);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Hotel hotel)
        {
            var result = _hotelService.Add(hotel);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

    }
}
