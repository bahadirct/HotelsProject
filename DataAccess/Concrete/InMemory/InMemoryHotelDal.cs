using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryHotelDal : IHotelDal
    {
        List<Hotel> _hotels;
        public InMemoryHotelDal()
        {
            //Veri tabanı sistemlerini Simüle etmek amaçlı test verileri
            _hotels = new List<Hotel>() {
                new Hotel{Id=1,Name="Can Hotel",Address="Kocaeli",Phone="0262-1111111",Contact="Bahadır Can Topçu",Stars=3,Url="www.Canhotel.com" },
                new Hotel{Id=1,Name="Bongo Hotel",Address="Muğla",Phone="0262-2222222",Contact="Sergen Yalçın",Stars=3,Url="www.Bongohotel.com" },
                new Hotel{Id=1,Name="Holly Hotel",Address="Antalya",Phone="0262-3333333",Contact="Ahmet Dursun",Stars=3,Url="www.Hollyhotel.com" },
            };
        }
        public List<Hotel> GetAll()
        {
            return _hotels;
        }
        public void Add(Hotel hotel)
        {
            _hotels.Add(hotel);
        }

        public void Delete(Hotel hotel)
        {
            Hotel hotelToDelete = _hotels.SingleOrDefault(p=>p.Id==hotel.Id);
            _hotels.Remove(hotel);
        }

        public void Update(Hotel hotel)
        {
            Hotel hotelToUpdate = _hotels.SingleOrDefault(p => p.Id == hotel.Id);
            hotelToUpdate.Name = hotel.Name;
        }

        public List<Hotel> GetAllByStar(int star)
        {
            return _hotels.Where(p => p.Stars == star).ToList();
        }

        public List<Hotel> GetAll(Expression<Func<Hotel, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Hotel Get(Expression<Func<Hotel, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
