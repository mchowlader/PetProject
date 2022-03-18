using System.IO;

namespace ManagementSystem.Foundation.Services
{
    public interface IDirectoryAdapter
    {
        bool Exists(string path);
        DirectoryInfo CreateDirectory(string path);
    }
}