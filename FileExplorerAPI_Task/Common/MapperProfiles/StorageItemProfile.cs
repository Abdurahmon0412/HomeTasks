using AutoMapper;
using FileExplorerAPI_Task.Models.Dtos;
using FileExplorerApplication_Task.FileStorage.Models.Storage;

namespace FileExplorerAPI_Task.Common.MapperProfiles;

public class StorageItemProfile : Profile
{
    public StorageItemProfile()
    {
        CreateMap<IStorageEntry, IStorageItemDto>();
        CreateMap<IStorageItemDto, IStorageEntry>();
    }
}