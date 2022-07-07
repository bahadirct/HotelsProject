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
                new Hotel{HotelId=1,HotelName="Can Hotel",HotelAdress="Kocaeli",HotelPhone="0262-1111111",HotelContact="Bahadır Can Topçu",HotelStars=3,HotelUrl="www.Canhotel.com" },
                new Hotel{HotelId=1,HotelName="Bongo Hotel",HotelAdress="Muğla",HotelPhone="0262-2222222",HotelContact="Sergen Yalçın",HotelStars=3,HotelUrl="www.Bongohotel.com" },
                new Hotel{HotelId=1,HotelName="Holly Hotel",HotelAdress="Antalya",HotelPhone="0262-3333333",HotelContact="Ahmet Dursun",HotelStars=3,HotelUrl="www.Hollyhotel.com" },
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
            Hotel hotelToDelete = _hotels.SingleOrDefault(p=>p.HotelId==hotel.HotelId);
            _hotels.Remove(hotel);
        }

        public void Update(Hotel hotel)
        {
            Hotel hotelToUpdate = _hotels.SingleOrDefault(p => p.HotelId == hotel.HotelId);
            hotelToUpdate.HotelName = hotel.HotelName;
        }

        public List<Hotel> GetAllByStar(int star)
        {
            return _hotels.Where(p => p.HotelStars == star).ToList();
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
