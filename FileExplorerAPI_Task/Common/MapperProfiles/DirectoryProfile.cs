using AutoMapper;
using FileExplorerAPI_Task.Models.Dtos;
using FileExplorerApplication_Task.FileStorage.Models.Storage;

namespace FileExplorerAPI_Task.Common.MapperProfiles;

public class DirectoryProfile : Profile
{
    public DirectoryProfile()
    {
        CreateMap<StorageDirectory, StorageDirectoryDto>();
        CreateMap<StorageDirectoryDto, StorageDirectory>();
    }
}