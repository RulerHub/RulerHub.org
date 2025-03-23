using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.FluentUI.AspNetCore.Components;
using RulerHub.Shared.Entities.Warehouses;

namespace RulerHub.Razor.Items.Components;

public partial class ItemCreateForm
{
    private EditContext _editContext = default!;
    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

    [Parameter]
    public Item Content { get; set; } = new();

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
                await ItemService.CreateAsync(model);
                ToastService.ShowSuccess("The Item has create susesful");
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
