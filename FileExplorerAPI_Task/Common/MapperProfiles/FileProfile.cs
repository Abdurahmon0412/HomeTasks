using AutoMapper;
using FileExplorerAPI_Task.Models.Dtos;
using FileExplorerApplication_Task.FileStorage.Models.Storage;

namespace FileExplorerAPI_Task.Common.MapperProfiles;

public class FileProfile : Profile
{
    public FileProfile()
    {
        CreateMap<StorageFile, StorageFileDto>();
        CreateMap<StorageFileDto, StorageFile>();
    }
}