using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class HotelManager : IHotelService
    {
        private readonly IHotelDal _hotelDal;

        public HotelManager(IHotelDal hotelDal)
        {
            _hotelDal=hotelDal; 
        }

        public IDataResult<List<Hotel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Hotel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Hotel> GetByStar(int star)
        {
            throw new NotImplementedException();
        }
    }
}
