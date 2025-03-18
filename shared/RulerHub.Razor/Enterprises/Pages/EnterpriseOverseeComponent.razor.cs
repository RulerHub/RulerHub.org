using Microsoft.FluentUI.AspNetCore.Components;
using RulerHub.Shared.Entities.Enterprises;


namespace RulerHub.Razor.Enterprises.Pages;

public partial class EnterpriseOverseeComponent
{
    public Enterprise? Enterprise { get; set; }

    FluentHorizontalScroll _horizontalScroll = default!;

    protected override async Task OnInitializedAsync()
    {
        await GetEnterprise();
    }

    protected async Task GetEnterprise()
    {
        Enterprise = await EnterpriseService.GetEnterprise();
    }
}
