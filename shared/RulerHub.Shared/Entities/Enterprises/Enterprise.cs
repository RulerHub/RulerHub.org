using RulerHub.Shared.Entities.Abstractions;
using RulerHub.Shared.Entities.Identity;
using RulerHub.Shared.Entities.Warehouses;

namespace RulerHub.Shared.Entities.Enterprises;

public class Enterprise : Entity
{
    public required string Name { get; set; }
    public string? Description { get; set; }

    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }


    public string? UserId { get; set; }
    public ApplicationUser? User { get; set; }

    public List<Warehouse> Warehouses { get; set; } = [];
}
