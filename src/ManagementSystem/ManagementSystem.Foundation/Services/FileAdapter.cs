using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Foundation.Services
{
    public class FileAdapter : IFileAdapter
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        protected readonly IPathService _pathService;
        private readonly IDirectoryAdapter _directoryAdapter;

        public FileAdapter(IWebHostEnvironment webHostEnvironment,
                           IPathService pathService,
                           IDirectoryAdapter directoryAdapter)
        {
            _webHostEnvironment = webHostEnvironment;
            _pathService = pathService;
            _directoryAdapter = directoryAdapter;
        }

        public bool Exists(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException("Provided path is null or empty");

            return File.Exists(path);
        }
    }
}
