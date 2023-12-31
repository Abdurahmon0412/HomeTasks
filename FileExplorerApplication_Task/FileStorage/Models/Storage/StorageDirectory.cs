﻿namespace FileExplorerApplication_Task.FileStorage.Models.Storage;

public class StorageDirectory : IStorageEntry
{
    public string Name { get; set; } = string.Empty;

    public string Path { get; set; } = string.Empty;

    public long ItemsCount { get; set; }

    public StorageItemType ItemType { get; set; }
}