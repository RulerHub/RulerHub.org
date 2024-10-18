namespace RulerHub.Services.Helpers;

public class QueryItem
{
    // Filtering
    public string? Code { get; set; } = null;
    public string? Name { get; set; } = null;
    // Sorting
    public string? SortBy { get; set; } = null;
    public bool IsDescending { get; set; } = false;
    // Pagination
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
