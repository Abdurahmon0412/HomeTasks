using FileStorogeN56.Models;

namespace FileStorogeN56.Extentions;

public static class UserExtensionMethods
{
    public static void InitializeUserFolders(this User user)
    {
        var absoluteUserPath = Path.Combine(Directory.GetCurrentDirectory(), "User");

        if (!Directory.Exists(absoluteUserPath))
            Directory.CreateDirectory(absoluteUserPath);

        var userPath = Path.Combine(absoluteUserPath, user.Id.ToString());

        if (!Directory.Exists(userPath))
            Directory.CreateDirectory(userPath);

        var userProfileFolderPath = Path.Combine(userPath, "Profile");
        var userResumeFolderPath = Path.Combine(userPath, "Resume");

        if (!Directory.Exists(userProfileFolderPath))
            Directory.CreateDirectory(userProfileFolderPath);

        if (!Directory.Exists(userResumeFolderPath))
            Directory.CreateDirectory(userResumeFolderPath);

    }
}
