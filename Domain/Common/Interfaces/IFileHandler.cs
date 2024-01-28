using Microsoft.AspNetCore.Http;

namespace Domain.Common.Interfaces
{
    public interface IFileHandler
    {
        Task UploadFileAsync(IFormFile file,  string folderName);
        string BuildPath(string folderName, string fileName);
    }
    
}