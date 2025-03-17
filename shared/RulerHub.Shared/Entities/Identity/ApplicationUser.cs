using Microsoft.AspNetCore.Identity;
using RulerHub.Shared.Entities.Enterprises;

namespace RulerHub.Shared.Entities.Identity;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public int? EnterpriceId { get; set; }
    public List<Enterprise>? Enterprice { get; set; } = [];
}

