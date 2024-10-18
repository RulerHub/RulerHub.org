using System.ComponentModel.DataAnnotations.Schema;

namespace RulerHub.Shared.DbModels;
// Item Db Model
[Table(name: "Items")]
public class ItemModel
{
    // navigation object
    public int? CategoryId { get; set; }
    public CategoryModel? Category { get; set; }
    [Column(name: "Id")]
    public int Id { get; set; }
    [Column(name: "Code")]
    public string Code { get; set; } = string.Empty;
    [Column(name: "Name")]
    public string Name { get; set; } = string.Empty;
    [Column(name: "Description")]
    public string Description { get; set; } = string.Empty;
    [Column(TypeName = "decimal(8, 2)")]
    public decimal Price { get; set; }
    [Column(name: "Quantity")]
    public int Quantity { get; set; }
    [Column(name: "IsInStock")]
    public bool IsInStock { get; set; }
}

