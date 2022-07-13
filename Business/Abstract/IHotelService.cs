using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IHotelService
    {
        IDataResult<List<Hotel>> GetAll();
        IDataResult<Hotel> GetById(int id);
        IDataResult<Hotel> GetAllByStar(int star);


    }
}
