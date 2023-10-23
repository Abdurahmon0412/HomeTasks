using AutoMapper;
using FileExplorer.API.Models.Dtos;
using FileExplorer.Appllication.FileStorage.Models.Storage;

namespace FileExplorer.API.Common.MapperProfiles;

public class DirectoryProfile : Profile
{
    public DirectoryProfile()
    {
        CreateMap<StorageDirectory, StorageDirectoryDto>();
        CreateMap<StorageDirectoryDto, StorageDirectory>();
    }
}