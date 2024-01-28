using Domain.Common.Interfaces;
using Domain.Common.Settings;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Core.FileHandler;

public class FileHandler : IFileHandler
{
    async Task IFileHandler.UploadFileAsync(IFormFile file,string path)
    {
        await using var fileStream = new FileStream(path, FileMode.Create);
        await file.CopyToAsync(fileStream);
    }
    
    string IFileHandler.BuildPath(string folderName, string fileName)
    {
        return Path.Combine(folderName, fileName);
    }
}