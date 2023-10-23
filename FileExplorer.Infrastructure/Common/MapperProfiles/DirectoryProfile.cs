using AutoMapper;
using FileExplorer.Appllication.FileStorage.Models.Storage;

namespace FileExplorer.Infrastructure.Common.MapperProfiles;

public class DirectoryProfile : Profile
{
    public DirectoryProfile()
    {
        CreateMap<DirectoryInfo, StorageDirectory>()
           .ForMember(src => src.Name, opt => opt.MapFrom(dest => dest.Name))
           .ForMember(src => src.Path, opt => opt.MapFrom(dest => dest.FullName))
           .ForMember(src => src.ItemsCount, opt => opt.MapFrom(dest => dest.GetFileSystemInfos().Count()));

    }
}