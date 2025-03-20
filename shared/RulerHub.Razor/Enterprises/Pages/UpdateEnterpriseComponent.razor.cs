using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.FluentUI.AspNetCore.Components;
using RulerHub.Shared.Entities.Enterprises;

namespace RulerHub.Razor.Enterprises.Pages;

public partial class UpdateEnterpriseComponent
{
    private EditContext _editContext = default!;
    [CascadingParameter]
    public FluentDialog Dialog { get; set; } = default!;

    [Parameter]
    public Enterprise Content { get; set; } = default!;

    public DateTime? SelectedDate = DateTime.Today.AddDays(-1);
    private DateTime? DoubleClickToDate = null;

    private bool DoubleClickToToday
    {
        get => DoubleClickToDate.HasValue;
        set => DoubleClickToDate = value ? DateTime.Today : null;
    }


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
            await EnterpriseService.UpdateEnterprise(Content);
            await Dialog.CloseAsync(Content);
        }
    }
}
