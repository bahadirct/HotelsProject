using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelsProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DenemeController : ControllerBase
    {
        [HttpGet]
        public List<Hotel> Get()
        {
            IHotelService hotelService = new HotelManager(new EfHotelDal());
            var result = hotelService.GetAll();
            return result.Data;

        }


    }
}
