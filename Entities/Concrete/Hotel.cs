using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Hotel : IEntity
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string HotelAdress { get; set; }
        public short HotelStars { get; set; }
        public string HotelContact { get; set; }
        public string HotelPhone { get; set; }
        public string HotelUrl { get; set; }
        
    }
}
