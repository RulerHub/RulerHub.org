using Microsoft.AspNetCore.Components;

namespace RulerHub.Components.Blogs.Pages.Shared;

public partial class BlogsCards
{
    [Parameter]
    public string Title { get; set; } = string.Empty;
    [Parameter]
    public string Description { get; set; } = string.Empty;
    [Parameter]
    public DateTime Date { get; set; }

    [Parameter]
    public string PictureLink { get; set; } = string.Empty;
    [Parameter]
    public string PictureAlt { get; set; } = string.Empty;
}
