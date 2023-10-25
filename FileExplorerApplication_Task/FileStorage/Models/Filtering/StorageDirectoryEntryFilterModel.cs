﻿using FileExplorerApplication_Task.Common.Models.Filtering;

namespace FileExplorerApplication_Task.FileStorage.Models.Filtering;

public class StorageDirectoryEntryFilterModel : FilterPagination
{
    public bool IncludeDirectories { get; set; }

    public bool IncludeFiles { get; set; }
}