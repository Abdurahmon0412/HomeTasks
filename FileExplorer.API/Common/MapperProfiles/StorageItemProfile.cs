using AutoMapper;
using FileExplorer.API.Models.Dtos;
using FileExplorer.Appllication.FileStorage.Models.Storage;

namespace FileExplorer.API.Common.MapperProfiles;

public class StorageItemProfile : Profile
{
    public StorageItemProfile()
    {
        CreateMap<IStorageEntry, IStorageItemDto>();
        CreateMap<IStorageItemDto, IStorageEntry>();
    }
}