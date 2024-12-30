using Microsoft.FluentUI.AspNetCore.Components;

namespace RulerHub.Components.Settings.Pages.Manage;

public partial class Index
{
    ActionLink<Message> link = new()
    {
        Text = "Learn more",
        Href = "https://bing.com",
    };

    int counter = 0;

    void AddInNotificationCenter()
    {
        MessageService.ShowMessageBar(options =>
        {
            options.Intent = Enum.GetValues<MessageIntent>()[1];
            options.Title = $"Notification #{counter++}";
            options.Body = "Some mesage for notification";
            options.Link = link;
            options.Timestamp = DateTime.Now;
            options.Section = App.MESSAGES_NOTIFICATION_CENTER;
        });
    }
}
