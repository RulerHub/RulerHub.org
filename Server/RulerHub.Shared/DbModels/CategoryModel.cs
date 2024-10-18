using System.ComponentModel.DataAnnotations.Schema;

namespace RulerHub.Shared.DbModels;

[Table(name: "Categories")]
public class CategoryModel
{
    [Column(name: "Id")]
    public int Id { get; set; }
    [Column(name: "Name")]
    public string Name { get; set; } = string.Empty;
    [Column(name: "Description")]
    public string Description { get; set; } = string.Empty;

    public List<ItemModel> Items { get; set; } = [];
}
