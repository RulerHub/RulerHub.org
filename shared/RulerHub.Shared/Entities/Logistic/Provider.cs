using RulerHub.Shared.Entities.Abstractions;

namespace RulerHub.Shared.Entities.Logistic;

public class Provider : Entity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;

    public List<Purchase>? Purchases { get; set; } = [];
}
