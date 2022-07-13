using Microsoft.EntityFrameworkCore;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Veri Tabanlı tabloları ile proje içindde kullandığımız tabloları ilişkilendiriyoruz.
    public class HotelProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=HotelDataBase;Trusted_Connection=true;");
           
        }

        
        public DbSet<Hotel> Hotels { get; set; }
    }
}
