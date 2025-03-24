using Microsoft.FluentUI.AspNetCore.Components;
using RulerHub.Shared.Entities.Enterprises;


namespace RulerHub.Razor.Enterprises.Pages;

public partial class EnterpriseOverseeComponent : IDialogContentComponent
{
    public Enterprise? Enterprise { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await GetEnterprise();
    }

    protected async Task GetEnterprise()
    {
        Enterprise = await EnterpriseService.GetEnterprise();
    }

    private async Task Update(Enterprise data)
    {
        var dialog = await DialogService.ShowDialogAsync<UpdateEnterpriseComponent>(data, new DialogParameters()
        {
            Height = "400px",
            Title = $"Update Enterprise {data.Name}",
            PreventDismissOnOverlayClick = true,
            PreventScroll = true,
        });

        var result = await dialog.Result;
        if (!result.Cancelled && result.Data != null)
        {
            await GetEnterprise();
            StateHasChanged();
        }

    }

    // create modal
    private async Task Create()
    {
        var dialog = await DialogService.ShowDialogAsync<EnterpriseCreateComponent>(new DialogParameters()
        {
            Height = "400px",
            Title = $"Create Warehouse",
            PreventDismissOnOverlayClick = true,
            PreventScroll = true,
        });

        var result = await dialog.Result;
        if (!result.Cancelled && result.Data != null)
        {
            await GetEnterprise();
            StateHasChanged();
        }
    }
}
