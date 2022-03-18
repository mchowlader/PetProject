using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Foundation.Services
{
    public class DirectoryAdapter : IDirectoryAdapter
    {
        public bool Exists(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException("Provided path is null or empty");

            return Directory.Exists(path);
        }

        public DirectoryInfo CreateDirectory(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException("Provided path is null or empty");

            return Directory.CreateDirectory(path);
        }
    }
}