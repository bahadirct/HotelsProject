using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IHotelDal
    {
        List<Hotel> GetAll();
        void Add(Hotel hotel);
        void Update(Hotel hotel);
        void Delete(Hotel hotel);

        List<Hotel> GetAllByStar(int star);
    }
}
