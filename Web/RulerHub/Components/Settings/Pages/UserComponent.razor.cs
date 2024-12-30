using Microsoft.FluentUI.AspNetCore.Components;

namespace RulerHub.Components.Settings.Pages;

public partial class UserComponent
{
    private IDialogReference? _dialog;

    UserUpdateForm.RegisterContent DialogData = new() { Id = 1, Name = "Adrian Mesa Sacasas", Age = 19 };

    private async Task OpenPnel()
    {
        var data = DialogData with { Id = 0 } ?? new();
        _dialog = await DialogService.ShowPanelAsync<UserUpdateForm>(data, new DialogParameters<UserUpdateForm>()
        {
            //Content = DialogData,
            Alignment = HorizontalAlignment.Right,
            Title = "Some title",
            PrimaryAction = "Yes",
            SecondaryAction = "No",
        });
        DialogResult result = await _dialog.Result;
        //HandlePanel(result);

    }

    private async Task EditAsync()
    {
        // Create a new instance of DialogData
        // to allow the user to cancel the update
        var data = DialogData with { Id = 0 } ?? new();

        var dialog = await DialogService.ShowDialogAsync<UserUpdateForm>(data, new DialogParameters()
        {
            Height = "400px",
            Title = $"Updating the {DialogData.Name} sheet",
            PreventDismissOnOverlayClick = true,
            PreventScroll = true,
        });

        var result = await dialog.Result;
        if (!result.Cancelled && result.Data != null)
        {
            DialogData = (UserUpdateForm.RegisterContent)result.Data;
        }

    }
}
