using Microsoft.AspNetCore.Http;

namespace Domain.Common.Interfaces
{
    public interface IFileHandler
    {
        Task UploadFileAsync(IFormFile file, long storeId, long productId);
        Task UploadMultpleFileAsync(IEnumerable<IFormFile> files, long storeId, long productId);
    }
}