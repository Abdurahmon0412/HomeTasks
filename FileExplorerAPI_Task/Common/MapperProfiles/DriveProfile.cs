using AutoMapper;
using FileExplorerAPI_Task.Models.Dtos;
using FileExplorerApplication_Task.FileStorage.Models.Storage;

namespace FileExplorerAPI_Task.Common.MapperProfiles;

public class DriveProfile : Profile
{
    public DriveProfile()
    {
        CreateMap<StorageDrive, StorageDriveDto>();
        CreateMap<StorageDriveDto, StorageDrive>();
    }
}