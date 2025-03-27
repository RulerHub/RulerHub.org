using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.JSInterop;
using RulerHub.Razor.Items.Components;
using RulerHub.Shared.Entities.Warehouses;

namespace RulerHub.Razor.Warehouses.Components;

public partial class WarehouseListComponent : IDialogContentComponent
{
    private IQueryable<Warehouse>? _Warehouses;
    string nameFilter = string.Empty;
    private readonly PaginationState pagination = new() { ItemsPerPage = 10 };

    [Inject]
    private IJSRuntime JSRuntime { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        await GetDataAsync();
    }

    private async Task GetDataAsync()
    {
        var warehouses = await WarehouseService.GetAsync();
        _Warehouses = warehouses.AsQueryable();
    }

    IQueryable<Warehouse>? FilteredWarehouses
    {
        get
        {
            return _Warehouses?.Where(x => x.Name.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase));
        }
    }

    private void HandleNameFilter(ChangeEventArgs args)
    {
        if (args.Value is string value)
        {
            nameFilter = value;
        }
    }

    // panel Oversee
    private async Task Oversee(Warehouse data)
    {
        DialogParameters<Warehouse> parameters = new()
        {
            Content = data,
            Title = $"Oversee {data.Name} Warehouse",
            OnDialogResult = DialogService.CreateDialogCallback(this, HandlePanelAsync),
            Alignment = HorizontalAlignment.Right,
            Modal = false,
            ShowDismiss = false,
            PrimaryAction = "Ok",
            SecondaryAction = "Cancel",
            Width = "600px"
        };
        await DialogService.ShowPanelAsync<WarehouseOverseePanel, Warehouse>(parameters);
    }

    // create modal
    private async Task Create()
    {
        var dialog = await DialogService.ShowDialogAsync<WarehouseCreateForm>(new DialogParameters()
        {
            Height = "400px",
            Title = $"Create Warehouse",
            PreventDismissOnOverlayClick = true,
            PreventScroll = true,
        });

        var result = await dialog.Result;
        if (!result.Cancelled && result.Data != null)
        {
            await GetDataAsync();
            StateHasChanged();
        }
    }

    // Update modal
    private async Task Update(Warehouse data)
    {
        var dialog = await DialogService.ShowDialogAsync<WarehouseUpdateForm>(data, new DialogParameters()
        {
            Height = "400px",
            Title = $"Update Warehouse {data.Name}",
            PreventDismissOnOverlayClick = true,
            PreventScroll = true,
        });

        var result = await dialog.Result;
        if (!result.Cancelled && result.Data != null)
        {
            await GetDataAsync();
            StateHasChanged();
        }
    }

    // Delete
    private async Task Delete(int Id, string Name)
    {
        await WarehouseService.DeleteAsync(Id);
        ToastService.ShowWarning($"Warehouse: {Name}. Eliminado");
        await GetDataAsync();
        StateHasChanged();
    }

    // handle panel
    private async Task HandlePanelAsync(DialogResult result)
    {
        if (result.Cancelled)
        {
            ToastService.ShowSuccess($"Action Canceled");
            return;
        }
        if (result.Data != null)
        {
            ToastService.ShowSuccess($"Action manage");
            return;
        }
        ToastService.ShowWarning($"Panel closed");
    }

    private static void ExportToPdf()
    {
        //    if (_Warehouses == null) return;

        //    var pdfBytes = PdfService.GeneratePdf(_Warehouses.ToList());
        //    var base64 = Convert.ToBase64String(pdfBytes);
        //    var fileName = "warehouses.pdf";
        //    var url = $"data:application/pdf;base64,{base64}";
        //    await JSRuntime.InvokeVoidAsync("downloadFileFromUrl", fileName, url);
    }
}
