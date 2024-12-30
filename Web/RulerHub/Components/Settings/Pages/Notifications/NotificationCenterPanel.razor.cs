using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.FluentUI.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RulerHub.Components.Settings.Pages.Notifications;

public partial class NotificationCenterPanel
{
    [Parameter]
    public GlobalState Content { get; set; } = default!;
}
