using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Results;

namespace Core.Utilities.Helpers
{
    public static class FileHelper
    {
        static string directory = "wwwroot";

        public static IResult GetDbFile(string fileName, IFormFile file)
        {
            try
            {
                string DbExtension = Path.GetExtension(file.FileName);
                string newFile = Guid.NewGuid().ToString("N") + DbExtension;
                string DbFolder = Path.Combine(directory, "DbFiles");
                string DbPath = Path.Combine(DbFolder, newFile);
                string DbFilePath = string.Format("/" + fileName + "/{0}", newFile);

                if (!Directory.Exists(DbFolder))
                    Directory.CreateDirectory(DbFolder);

                using (FileStream fileStream = File.Create(DbPath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }
                return new Result(true, "");
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }


    }
}