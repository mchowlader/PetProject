using System.IO;
using System.Threading.Tasks;


namespace ManagementSystem.Foundation.Services
{
    public interface ISystemImageResizer
    {
        Task<FileInfo> ProfileImageResizeAsync(FileInfo temporaryImageFile);
    }
}