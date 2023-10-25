namespace FileExplorerAPI_Task.Models.Dtos;

public class FilterModel
{
    public int PageSize { get; set; } = 10;

    public int PageToken { get; set; } = 1;

    public bool IncludeDirectories { get; set; } = true;

    public bool IncludeFiles { get; set; } = true;

    public string? SearchKeyword { get; set; }
}
