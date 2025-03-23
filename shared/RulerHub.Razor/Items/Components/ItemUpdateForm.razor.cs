using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.FluentUI.AspNetCore.Components;
using RulerHub.Shared.Entities.Warehouses;

namespace RulerHub.Razor.Items.Components;

public partial class ItemUpdateForm
{
    private EditContext _editContext = default!;
    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

    [Parameter]
    public Item Content { get; set; } = default!;

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
            ToastService.ShowSuccess("Update Item");
            await ItemService.UpdateAsync(Content.Id, Content);
            await Dialog.CloseAsync(Content);
        }
    }
}
