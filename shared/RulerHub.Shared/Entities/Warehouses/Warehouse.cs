using System.ComponentModel.DataAnnotations.Schema;
using RulerHub.Shared.Entities.Abstractions;
using RulerHub.Shared.Entities.Enterprises;
using RulerHub.Shared.Entities.Sales;

namespace RulerHub.Shared.Entities.Warehouses;

public class Warehouse : Entity
{
    public string Name { get; set; } = string.Empty;

    public int? EnterpriceId { get; set; }
    public Enterprise? Enterprise { get; set; }

    public List<Department> Departments { get; set; } = [];
    public List<Category> Categories { get; set; } = [];
    public List<Item> Items { get; set; } = [];

    [Column(TypeName = "decimal(8, 2)")]
    public decimal WarehousePrice { get; set; }
}
