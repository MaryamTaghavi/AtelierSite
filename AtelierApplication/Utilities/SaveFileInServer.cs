using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Atelier.Application.Utilities
{
    public static class SaveFileInServer
    {
        public static  string SaveFile(this IFormFile inputTarget, string savePath)
        {
            if (inputTarget == null) 
                return "File Not Found";

            var pathSave = "wwwroot\\" + savePath;


			string extension = Path.GetExtension(inputTarget.FileName);
            

            var fileName = Guid.NewGuid() + extension;


            var folderName = Path.Combine(Directory.GetCurrentDirectory(), pathSave.Replace("/", "\\"));

            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);
            

            var path = Path.Combine(folderName, fileName);
            using var stream = new FileStream(path, FileMode.Create);
            inputTarget.CopyTo(stream);
            return "\\" + savePath+fileName;
        }

        public static void DeleteFile(this string pathName)
        {
            string deletePath = Path.Combine(Directory.GetCurrentDirectory(), pathName);
                if (File.Exists(deletePath))
                   File.Delete(deletePath);
        }
    }
}