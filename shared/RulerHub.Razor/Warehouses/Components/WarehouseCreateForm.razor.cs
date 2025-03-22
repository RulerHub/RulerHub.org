using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.FluentUI.AspNetCore.Components;
using RulerHub.Shared.Entities.Warehouses;

namespace RulerHub.Razor.Warehouses.Components;

public partial class WarehouseCreateForm
{
    private EditContext _editContext = default!;
    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

    [Parameter]
    public Warehouse Content { get; set; } = new();

    protected override void OnInitialized()
    {
        _editContext = new EditContext(Content);

    }

    private async Task SaveAsync()
    {
        if (_editContext.Validate())
        {
            var model = Content;
            if (model.Name == "Name" && model.Name == "Name")
            {
                ToastService.ShowWarning("Datos Invalidos");
                await Dialog.CancelAsync();
            }
            else
            {
                await WarehouseService.CreateAsync(model);
                ToastService.ShowSuccess("The warehouse has create susesful");
                await Dialog.CloseAsync(Content);
            }


        }
    }

    private async Task CancelAsync()
    {
        ToastService.ShowWarning("Create cancel");
        await Dialog.CancelAsync();
    }
}
