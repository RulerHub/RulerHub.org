using RulerHub.Shared.Entities.Abstractions;
using RulerHub.Shared.Entities.Warehouses;
using System.ComponentModel.DataAnnotations.Schema;

namespace RulerHub.Shared.Entities.Sales;

public class Department : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public List<Item> Items { get; set; } = [];

    [Column(TypeName = "decimal(8, 2)")]
    public decimal DepartmentPrice { get; set; }
}