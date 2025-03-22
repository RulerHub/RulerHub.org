using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.FluentUI.AspNetCore.Components;
using RulerHub.Shared.Entities.Warehouses;

namespace RulerHub.Razor.Warehouses.Components;

public partial class WarehouseUpdateForm
{
    private EditContext _editContext = default!;
    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

    [Parameter]
    public Warehouse Content { get; set; } = default!;

    protected override void OnInitialized()
    {
        _editContext = new EditContext(Content);
    }

    private async Task CancelAsync()
    {
        ToastService.ShowWarning("Create cancel");
        await Dialog.CancelAsync();
    }

    private async Task SaveAsync()
    {
        if (_editContext.Validate())
        {
            ToastService.ShowSuccess("Update Warehouse");
            await WarehouseService.UpdateAsync(Content.Id, Content);
            await Dialog.CloseAsync(Content);
        }
    }
}
