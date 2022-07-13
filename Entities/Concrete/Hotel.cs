using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using IndexAttribute = CsvHelper.Configuration.Attributes.IndexAttribute;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using CsvHelper.Configuration;
using System.Globalization;

namespace Entities.Concrete
{
    
    public class Hotel : IEntity
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Index(0)]
        public string Name { get; set; }
        [Index(1)]
        public string Address { get; set; }
        [Index(2)]
        public int Stars { get; set; }
        [Index(3)]
        public string Contact { get; set; }
        [Index(4)]
        public string Phone { get; set; }
        [Index(5)]
        public string Url { get; set; }     
    }

    public sealed class HotelMap : ClassMap<Hotel>
    {
        public HotelMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Id).Ignore();
        }
    }
}
