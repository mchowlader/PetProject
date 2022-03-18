using Microsoft.AspNetCore.Http;

namespace ManagementSystem.Foundation.Services
{
    public interface IFileStoreUtility
    {
        public (string fileName, string filePath) StoreFile(IFormFile file);
    }
}