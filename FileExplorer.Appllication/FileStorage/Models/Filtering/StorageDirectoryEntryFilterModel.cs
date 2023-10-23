using FileExplorer.Appllication.Common.Models.Filtering;

namespace Training.FileExplorer.Application.FileStorage.Models.Filtering;

public class StorageDirectoryEntryFilterModel : FilterPagination
{
    public bool IncludeDirectories { get; set; }

    public bool IncludeFiles { get; set; }
}