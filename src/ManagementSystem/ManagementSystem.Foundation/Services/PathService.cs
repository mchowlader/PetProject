using ManagementSystem.Foundation.Utilities;
using Microsoft.Extensions.Options;
using System;
using System.IO;

namespace ManagementSystem.Foundation.Services
{
    public class PathService : IPathService
    {
        public string DefaultFileStoragePath { get; private set; }
        public string DefaultProfileImagePath { get; private set; }
        public string TempFolder { get; private set; }
        public string DefaultProfileImage { get; private set; }
        public string ProfileImagePath { get; private set; }
        public string DefaultMaleAvaterImagePath { get; private set; }



        public PathService(IOptions<PathSettings> settings, IOptions<DefaultImageSettings> defaultSiteSettings)
        {
            var paths = settings.Value;
            var defaultSitePaths = defaultSiteSettings.Value;
            ProfileImagePath = paths.ProfileImagePath;
            DefaultFileStoragePath = paths.DefaultFileStoragePath;
            DefaultProfileImagePath = paths.DefaultProfileImagePath;
            TempFolder = paths.TempFolder;
            DefaultProfileImage = defaultSitePaths.DefaultProfileImage;
        }

        public string AttachPathWithFile(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new InvalidOperationException("File name must be provided to attach path with file!");

            return Path.Combine(DefaultFileStoragePath, fileName);
        }

        public string AttachPathWithDefaultProfileImage(string defaultProfileImageName)
        {
            if (string.IsNullOrWhiteSpace(defaultProfileImageName))
                throw new InvalidOperationException("Default Profile image name must be provided to attach path with Default Profile image!");

            return Path.Combine(DefaultProfileImagePath, DefaultProfileImage);
        }
    }
}