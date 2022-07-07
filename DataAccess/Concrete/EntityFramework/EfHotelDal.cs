using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    internal class EfHotelDal : IHotelDal
    {
        public void Add(Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public void Delete(Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public List<Hotel> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Hotel> GetAllByStar(int star)
        {
            throw new NotImplementedException();
        }

        public void Update(Hotel hotel)
        {
            throw new NotImplementedException();
        }
    }
}
