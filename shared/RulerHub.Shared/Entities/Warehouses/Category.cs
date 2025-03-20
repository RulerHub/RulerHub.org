using RulerHub.Shared.Entities.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace RulerHub.Shared.Entities.Warehouses;

public class Category : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public List<Item> Items { get; set; } = [];

    [Column(TypeName = "decimal(8, 2)")]
    public decimal CategoryPrice { get; set; }
}
