using Microsoft.AspNetCore.Http;

namespace Atelier.Application.Helpers
{
    public interface IFileUploader
    {
        string Upload(IFormFile file, string path, string oldPath = null);
    }
}