using BlaBlaHotel_Server.Service.iService;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlaBlaHotel_Server.Service
{

    // vi använde oss av FileUpload för att kunna spara filer/bilder under programmets lokala wwwroot map
    public class FileUpload : iFileUpload
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUpload(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public bool DeleteFile(string FileName)
        {  
            try
            {
                var path = $"{_webHostEnvironment.WebRootPath}\\RoomImages\\{FileName}";
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> UploadFile(IBrowserFile File)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(File.Name);
                var fileName = Guid.NewGuid().ToString() + fileInfo.Extension;
                var folderdirectory = $"{_webHostEnvironment.WebRootPath}\\RoomImages";
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "RoomImages", fileName);

                var memoryStream = new MemoryStream();
                await File.OpenReadStream().CopyToAsync(memoryStream);

                if (!Directory.Exists(folderdirectory))
                {
                    Directory.CreateDirectory(folderdirectory);
                }

                await using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    memoryStream.WriteTo(fs);
                }
                var fullpath = $"RoomImages/ {fileName}";
                return fullpath;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
