using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace ProjectManagement.BusinessLogic
{

    public static class FileHandler
    {
        public static string UploadedFile(IFormFile file, string webRootPath, string subPath)
        {
            if (file == null) return null;

            var uploadsFolder = Path.Combine(webRootPath, $"FILES/{subPath}");
            var fileExtension = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid() + "." + fileExtension;
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return fileName;
        }
    }
}