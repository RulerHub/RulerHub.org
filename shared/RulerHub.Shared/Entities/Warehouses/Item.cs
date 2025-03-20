using RulerHub.Shared.Entities.Abstractions;
using RulerHub.Shared.Entities.Sales;
using System.ComponentModel.DataAnnotations.Schema;

namespace RulerHub.Shared.Entities.Warehouses;

[Table(name: "Items")]
public class Item : Entity
{
    [Column(name: "Code")]
    public string Code { get; set; } = string.Empty;
    [Column(name: "Name")]
    public string Name { get; set; } = string.Empty;
    [Column(name: "Description")]
    public string Description { get; set; } = string.Empty;

    public int CategoryId { get; set; }
    public Category Category { get; set; } = new Category();

    public int DepartmentId { get; set; }
    public Department Department { get; set; } = new Department();

    public int WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; } = new Warehouse();

    [Column(name: "MeasureUnit")]
    public string MeasureUnit { get; set; } = string.Empty;
    [Column(TypeName = "decimal(8, 5)")]
    public decimal Amount { get; set; }
    [Column(TypeName = "decimal(8, 2)")]
    public decimal Price { get; set; }
    [Column(TypeName = "decimal(8, 2)")]
    public decimal LastPrice { get; set; }
}
