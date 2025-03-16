
using RulerHub.Shared.Entities.Identity;

namespace RulerHub.Shared.Entities.Enterprices;

public class Enterprice
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public string? UserId { get; set; }
    public ApplicationUser? User { get; set; }
}
