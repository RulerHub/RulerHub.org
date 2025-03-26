using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.FluentUI.AspNetCore.Components;
using RulerHub.Data.Services.Enterprises.Interfaces;
using RulerHub.Data.Services.Statistics.Interfaces;
using RulerHub.Shared.Entities.Enterprises;
using RulerHub.Shared.Localization;


namespace RulerHub.Razor.Enterprises.Pages;

public partial class EnterpriseOverseeComponent : IDialogContentComponent
{
    [Inject]
    public IStatisticsService StatisticsService { get; set; }

    [Inject]
    public IEnterpriseService EnterpriseService { get; set; }

    [Inject]
    public IStringLocalizer<Language> Localizer { get; set; }

    public Enterprise? Enterprise { get; set; }

    private int totalProviders;
    private int totalPurchases;

    protected override async Task OnInitializedAsync()
    {
        await GetEnterprise();
        await GetStatistic();
    }

    private async Task GetStatistic()
    {
        try
        {
            totalProviders = await StatisticsService.GetTotalProvidersAsync();
            totalPurchases = await StatisticsService.GetTotalPurchasesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            var errorMessage = Localizer["E0012"];
        }
    }

    private async Task GetEnterprise()
    {
        try
        {
            Enterprise = await EnterpriseService.GetEnterprise();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            var errorMessage = Localizer["E0013"];
        }
    }

    private async Task Update(Enterprise data)
    {
        try
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
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            var errorMessage = Localizer["E0014"];
        }
    }

    private async Task Create()
    {
        try
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
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            var errorMessage = Localizer["E0015"];
        }
    }
}
