using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;

namespace ManagementSystem.Foundation.Services
{
    public class FileStoreUtility : IFileStoreUtility
    {
        private IPathService _pathService;
        private IWebHostEnvironment _webHostEnvironment;
        private readonly IDirectoryAdapter _directoryAdapter;

        public FileStoreUtility() { }

        public FileStoreUtility(IWebHostEnvironment webHostEnvironment,
                           IPathService pathService,
                           IDirectoryAdapter directoryAdapter)
        {
            _webHostEnvironment = webHostEnvironment;
            _pathService = pathService;
            _directoryAdapter = directoryAdapter;
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _pathService = scope.Resolve<IPathService>();
            _webHostEnvironment = scope.Resolve<IWebHostEnvironment>();
        }

        public (string fileName, string filePath) StoreFile(IFormFile file)
        {
            var randomName = Path.GetRandomFileName().Replace(".", string.Empty);
            var newFileName = $"{randomName}{Path.GetExtension(file.FileName)}";
            var rootPath = _webHostEnvironment.WebRootPath;
            var defaultStoragePath = _pathService.DefaultFileStoragePath;

            if (!_directoryAdapter.Exists(Path.Combine(rootPath, defaultStoragePath)))
            {
                _directoryAdapter.CreateDirectory(Path.Combine(rootPath, defaultStoragePath));
            }

            var path = Path.Combine(rootPath, defaultStoragePath, newFileName);

            if (!File.Exists(path))
            {
                using var profileImage = File.OpenWrite(path);
                using var uploadFile = file.OpenReadStream();
                uploadFile.CopyTo(profileImage);
            }

            return (newFileName, path);
        }
    }
}