using FileStorageConsole.Models;

namespace FileStorageConsole.Extentions;

public static class UserExtention
{
    public static void InitializeUserFoldersAsync(this User user)
    {
        var absalutePath = Path.Combine(Directory.GetCurrentDirectory(),"Storage", "User");

        if (!Directory.Exists(absalutePath))
            Directory.CreateDirectory(absalutePath);

        var userPath = Path.Combine(absalutePath, user.Id.ToString());

        if (!Directory.Exists(userPath)) 
            Directory.CreateDirectory(userPath);

        var userProfilePath = Path.Combine(userPath, "Profile");
        var UserResumePath = Path.Combine(userPath, "Resume");

        if(!Directory.Exists(userProfilePath))
            Directory.CreateDirectory($"{userProfilePath}");

        if (!Directory.Exists(UserResumePath))
            Directory.CreateDirectory($"{UserResumePath}");
    }
}