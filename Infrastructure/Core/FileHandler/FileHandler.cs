using Domain.Common.Interfaces;
using Domain.Common.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.IO;

namespace Infrastructure.Core.FileHandler;

public class FileHandler(IOptions<FileDirectorySettings> fileSettings) :IFileHandler
{
    
    public async Task UploadFileAsync(IFormFile file, long storeId, long productId)
    {
        var path = BuildPath(file.FileName, storeId, productId);
        using Stream fileStream = new FileStream(path, FileMode.Create);
        await file.CopyToAsync(fileStream);
    }
    
    string BuildPath(string fileName, long storeId, long productId)
    {
        string path = Path.Combine(fileSettings.Value.Root,storeId.ToString(),productId.ToString());
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        return Path.Combine(path, fileName);
    }

    public async Task UploadMultpleFileAsync(IEnumerable<IFormFile> files, long storeId, long productId)
    {
        foreach (var file in files)
        {
            await UploadFileAsync(file, storeId, productId);
        }
    }
}