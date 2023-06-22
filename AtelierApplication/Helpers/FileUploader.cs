using System;
using System.IO;
using Atelier.Application.CheckImage;
using Microsoft.AspNetCore.Http;

namespace Atelier.Application.Helpers
{
    public class FileUploader : IFileUploader
    {
        public string Upload(IFormFile file, string path, string oldPath)
        {
            if (file == null || !file.IsImage())
                return oldPath;

            DeleteFile(oldPath);

            var folderName = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Images\\{path}";

            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);

            string extension = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid() + extension}";

            var filePath = Path.Combine(folderName, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(stream);

            return $"\\Images\\{path}\\{fileName}";
        }

        private void DeleteFile(string path)
        {
            if (path == null)
                return;

            var folderName = $"{Directory.GetCurrentDirectory()}\\wwwroot";
            var filePath = folderName + path;

            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}