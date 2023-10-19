namespace WorkingWithFiles.FilesManagementService;

public class FilesManagementService
{
    public void FilesAndFoldersCount(string folderPath)
    {
        var directory = new DirectoryInfo(folderPath);
        var files = directory.GetFiles();
        var directories = directory.GetDirectories();

        Console.WriteLine(directories.Count());
        Console.WriteLine(files.Count());

    }

    public void AllFilesLenght(string folderPath)
    {
        var directory = new DirectoryInfo(folderPath);
        var files = directory.GetFiles();
        var directories = directory.GetDirectories();


        var filesLength = 0;
        var theMostFileLenght = 0;
        foreach (var file in files)
        {
            filesLength += (int)file.Length;
            if(theMostFileLenght < file.Length)
                theMostFileLenght = (int)file.Length;
        }

        Console.WriteLine($"all files lenght {filesLength} the most length {theMostFileLenght}");
    }
}