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


        public static void DeleteFile(string webRootPath, string subPath, string fileName)
        {
            if (fileName == null) return;

            var uploadsFolder = Path.Combine(webRootPath, $"FILES/{subPath}");
            // Check if file exists with its full path    
            if (File.Exists(Path.Combine(uploadsFolder, fileName)))
            {
                // If file found, delete it    
                File.Delete(Path.Combine(uploadsFolder, fileName));
            }
        }
    }
}