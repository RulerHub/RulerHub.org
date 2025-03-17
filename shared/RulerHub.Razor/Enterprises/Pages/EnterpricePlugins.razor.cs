using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace RulerHub.Razor.Enterprises.Pages;

public partial class EnterpricePlugins
{
    FluentHorizontalScroll _horizontalScroll = default!;

    [Parameter]
    public int WarehouseCount { get; set; }

    private void GotoWarehouseManage()
    {
        NavigationManager.NavigateTo("warehouse/home");
    }

}
