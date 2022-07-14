using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IHotelService
    {
        IResult Add(Hotel hotel);
        IResult AddRange(IEnumerable<Hotel> hotel);
        IDataResult<List<Hotel>> GetAll();
        IDataResult<Hotel> GetByName(string name);
        IDataResult<Hotel> GetAllByStar(int star);
        IResult WriteAsJson(string path, List<Hotel> hotels);
        IResult WriteAsXml(string path, List<Hotel> hotels);
        IResult GetDbFile(IFormFile file);

    }
}
