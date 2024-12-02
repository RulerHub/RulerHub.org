using Microsoft.FluentUI.AspNetCore.Components;

namespace eStore.Web.Components.Settings.Pages;

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
}
