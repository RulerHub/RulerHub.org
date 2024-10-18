using RulerHub.Shared.DataTransferObjects.Item;

namespace RulerHub.Shared.DataTransferObjects.Category;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public List<ItemDto> Items { get; set; } = [];
}
