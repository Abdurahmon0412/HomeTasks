using FileExplorer.Appllication.Common.Models.Filtering;

namespace Training.FileExplorer.Application.FileStorage.Models.Filtering;

public class StorageDriveEntryFilterModel : FilterPagination
{
    public bool IncludeDirectories { get; set; }

    public bool IncludeFiles { get; set; }
}