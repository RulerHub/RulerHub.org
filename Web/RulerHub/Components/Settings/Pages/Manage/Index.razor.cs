using Microsoft.FluentUI.AspNetCore.Components;

namespace RulerHub.Components.Settings.Pages;

public partial class Index
{
    private IDialogReference? _dialog;

    private async Task OpenPnel()
    {
        //var data = DateTime.Now;
        //_dialog = await DialogService.ShowPanelAsync<PersonaliseForm>(data, new DialogParameters<PersonaliseForm>()
        //{
        //    //Content = DialogData,
        //    Alignment = HorizontalAlignment.Right,
        //    Title = "Some title",
        //    PrimaryAction = "Yes",
        //    SecondaryAction = "No",
        //});
        //DialogResult result = await _dialog.Result;
    }
}
