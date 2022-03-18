
namespace ManagementSystem.Foundation.Services
{
    public interface IPathService
    {
        string DefaultFileStoragePath { get; }
        string ProfileImagePath { get; }
        string DefaultMaleAvaterImagePath { get; }
        string DefaultProfileImagePath { get; }
        string DefaultProfileImage { get; }
        string TempFolder { get; }

        string AttachPathWithFile(string fileName);
        string AttachPathWithDefaultProfileImage(string defaultProfileImageName);

    }
}