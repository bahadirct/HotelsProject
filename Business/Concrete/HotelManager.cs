using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using CsvHelper;
using CsvHelper.Configuration;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Business.Concrete
{
    public class HotelManager : IHotelService
    {
        private readonly IHotelDal _hotelDal;
        static string directory = "wwwroot";
        static string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/DbFiles/hotel");

        public HotelManager(IHotelDal hotelDal)
        {
            _hotelDal = hotelDal;
        }

        public IDataResult<List<Hotel>> GetAll()
        {
            //JsonConvert.SerializeObject(GELENDATA)
            return new SuccessDataResult<List<Hotel>>(_hotelDal.GetAll(), Messages.HotelList);
        }

        public IDataResult<Hotel> GetAllByStar(int stars)
        {
            return new SuccessDataResult<Hotel>(_hotelDal.Get(c => c.Stars == stars));
        }

        public IDataResult<Hotel> GetByName(string name)
        {
            return new SuccessDataResult<Hotel>(_hotelDal.Get(c => c.Name.Contains(name)));
        }
        //valid

        [ValidationAspect(typeof(HotelValidator))]
        public IResult GetDbFile(IFormFile file)
        {
            try
            {
                string DbExtension = Path.GetExtension(file.FileName);
                string newFile = file.FileName.ToLower();
                string DbFolder = Path.Combine(directory, "DbFiles");
                string DbPath = Path.Combine(DbFolder, newFile);

                if (!Directory.Exists(DbFolder))
                    Directory.CreateDirectory(DbFolder);

                using (FileStream fileStream = File.Create(DbPath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }

                List<Hotel> records;
                using (var reader = new StreamReader(DbPath))
                {
                    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        Delimiter = ",",
                        HasHeaderRecord = true
                    };

                    using (var csv = new CsvReader(reader, csvConfig))
                    {
                        csv.Context.RegisterClassMap<HotelMap>();
                        records = csv.GetRecords<Hotel>().ToList();

                    }
                }

                //TODO: validation rule buraya eklenebiliyorsa hotelDal kullan yoksa this olanı kullan.
                
                //_hotelDal.AddRange(records);
                this.AddRange(records);

                return new Result(true, "Dosya Yüklendi");
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }

        }

        public IResult WriteAsJson()
        {
            string jsonValue = JsonConvert.SerializeObject(_hotelDal.GetAll());

            if (!File.Exists(path))
            {
                using (var writer = new StreamWriter(path+".json"))
                {
                    writer.Write(jsonValue);
                }
                return new Result(true, "JSON dosyası oluşturuldu");
            }
            return new Result(false, "İşlem başarısız");
        }

        public IResult WriteAsXml()
        {
            if (!File.Exists(path))
            {
                using (var writer = XmlWriter.Create(path+".xml"))
                {
                    var columnNames = typeof(Hotel).GetProperties().Select(p => p.Name).ToArray();
                    writer.WriteStartDocument();
                    foreach (var hotel in _hotelDal.GetAll())
                    {
                        writer.WriteStartElement(columnNames[1]);
                        writer.WriteValue(hotel.Name);
                        writer.WriteStartElement(columnNames[2]);
                        writer.WriteValue(hotel.Address);
                        writer.WriteStartElement(columnNames[3]);
                        writer.WriteValue(hotel.Stars);
                        writer.WriteStartElement(columnNames[4]);
                        writer.WriteValue(hotel.Contact);
                        writer.WriteStartElement(columnNames[5]);
                        writer.WriteValue(hotel.Phone);
                        writer.WriteStartElement(columnNames[6]);
                        writer.WriteValue(hotel.Url);
                    }
                    writer.WriteEndElement();
                }
                return new Result(true, "XML dosyası oluşturuldu.");
            }
            return new Result(false, "İşlem başarısız");
        }
    

        [ValidationAspect(typeof(HotelValidator))]
        public IResult Add(Hotel hotel)
        {
            _hotelDal.Add(hotel);
            return new SuccessResult(Messages.HotelsAdded);
        }

        [ValidationAspect(typeof(HotelValidator))]
        public IResult AddRange(IEnumerable<Hotel> hotel)
        {
            _hotelDal.AddRange(hotel);
            return new SuccessResult(Messages.HotelsAdded);
        }

        //

    }
}
