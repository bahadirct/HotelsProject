using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    internal class EfHotelDal : IHotelDal
    {
        public void Add(Hotel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Hotel entity)
        {
            throw new NotImplementedException();
        }

        public Hotel Get(Expression<Func<Hotel, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Hotel> GetAll(Expression<Func<Hotel, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Hotel entity)
        {
            throw new NotImplementedException();
        }
    }
}

