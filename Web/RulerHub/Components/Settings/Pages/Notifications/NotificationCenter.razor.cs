using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

namespace RulerHub.Components.Settings.Pages.Notifications;

public partial class NotificationCenter
{
    private IDialogReference? _dialog;

    protected override void OnInitialized()
    {
        MessageService.OnMessageItemsUpdated += UpdateCount;
    }

    private void UpdateCount()
    {
        InvokeAsync(StateHasChanged);
    }

    private async Task OpenNotificationCenterAsync()
    {
        _dialog = await DialogService.ShowPanelAsync<NotificationCenterPanel>(new DialogParameters<GlobalState>()
        {
            Alignment = HorizontalAlignment.Right,
            Title = $"Notifications",
            PrimaryAction = null,
            SecondaryAction = null,
            ShowDismiss = true
        });
        DialogResult result = await _dialog.Result;
        HandlePanel(result);
    }

    private static void HandlePanel(DialogResult result)
    {
        if (result.Cancelled)
        {
            return;
        }

        if (result.Data is not null)
        {
            return;
        }
    }

    public void Dispose()
    {
        MessageService.OnMessageItemsUpdated -= UpdateCount;
    }
}
