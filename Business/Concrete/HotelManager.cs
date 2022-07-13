using Business.Abstract;
using Business.Constants;
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
            return new SuccessDataResult<List<Hotel>>(_hotelDal.GetAll(),Messages.HotelList);
        }

        public IDataResult<Hotel> GetAllByStar(int stars)
        {
            return new SuccessDataResult<Hotel>(_hotelDal.Get(c => c.Stars == stars));
        }

        public IDataResult<Hotel> GetById(int id)
        {
            return new SuccessDataResult<Hotel>(_hotelDal.Get(c => c.Id == id));
        }

        //
        
    }
}
