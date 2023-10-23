using System.Text.Json.Serialization;

namespace FileExplorer.Appllication.Common.Models.Filtering; 

public class FilterPagination
{
    public virtual uint PageSize { get; set; } = 10;

    public virtual uint PageToken { get; set; } = 1;

    [JsonIgnore] public uint DynamicPageSize => DynamicPagination?.PageSize ?? PageSize;

    [JsonIgnore] DynamicFilterPagination? DynamicPagination { get; set; }

    public void SetDynamicPagination(uint callsCount) => DynamicPagination = new DynamicFilterPagination(this, callsCount);

    public void ResetDynamicPagination() => DynamicPagination = null;
}