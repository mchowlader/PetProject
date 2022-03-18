using DevSkill.Core.Services;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ManagementSystem.Foundation.Services
{
    public class SystemImageResizer : ISystemImageResizer
    {
        private readonly IImageResizer _imageResizer;
        private readonly IPathService _pathService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SystemImageResizer(
           IImageResizer imageResizer,
           IPathService pathService,
           IWebHostEnvironment webHostEnvironment)
        {
            _imageResizer = imageResizer;
            _pathService = pathService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<FileInfo> ProfileImageResizeAsync(FileInfo temporaryImageFile)
        {
            const uint profileImageWidth = 140;

            if (temporaryImageFile == null)
            {
                throw new InvalidOperationException("Temporary image file is missing.");
            }

            var destinationFolder = _pathService.DefaultFileStoragePath;
            var destinationDirectoryInfo = GetCombinedPathDirectoryInfo(destinationFolder);

            var profileImagefileInfo = await _imageResizer.ResizeAsync(temporaryImageFile,
                destinationDirectoryInfo,
                profileImageWidth);

            return profileImagefileInfo;
        }

        private DirectoryInfo GetCombinedPathDirectoryInfo(string destinationFolder)
        {
            if (destinationFolder == null)
            {
                throw new InvalidOperationException("DestinationFolder is missing!");
            }

            var rootPath = _webHostEnvironment.WebRootPath;

            if (rootPath == null)
            {
                throw new InvalidOperationException("Rootpath is missing!");
            }

            var destinationFolderPath = Path.Combine(rootPath, destinationFolder);
            var destinationDirectoryInfo = new DirectoryInfo(destinationFolderPath);

            return destinationDirectoryInfo;
        }
    }
}