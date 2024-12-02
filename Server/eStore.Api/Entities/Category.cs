namespace eStore.Api.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    public DateTime CreateDate { get; set; } = DateTime.Now;

    public List<Product> Products { get; set; } = [];
}
