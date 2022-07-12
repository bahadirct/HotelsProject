﻿using Business.Abstract;
using Business.Concrete;
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
    public class HotelController : ControllerBase
    {
        IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        //HotelManager _hotelManager;

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
            var result =  _hotelService.GetByStar(star);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
