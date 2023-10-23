using AutoMapper;
using FileExplorer.API.Models.Dtos;
using FileExplorer.Appllication.FileStorage.Models.Storage;

namespace FileExplorer.API.Common.MapperProfiles;

public class FileProfile : Profile
{
    public FileProfile()
    {
        CreateMap<StorageFile, StorageFileDto>();
        CreateMap <StorageFileDto, StorageFile>();
    }
}