using System.ComponentModel.DataAnnotations.Schema;
using RulerHub.Shared.DataTransferObjects.Logistic.Items;

namespace RulerHub.Shared.DataTransferObjects.Logistic.Categories;

public class CategoryDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public List<ItemDto> Items { get; set; } = [];

    [Column(TypeName = "decimal(8, 2)")]
    public decimal CategoryPrice { get; set; }
}
