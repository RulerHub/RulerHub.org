using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using RulerHub.Shared.Entities.Warehouses;

namespace RulerHub.Razor.Items.Components;

public partial class ItemOverseePanel : IDialogContentComponent<Item>
{
    [Parameter]
    public Item Content { get; set; } = default!;
}
