using RulerHub.Shared.DataTransferObjects.Logistic.Purchases;
using System.ComponentModel.DataAnnotations;

namespace RulerHub.Shared.DataTransferObjects.Logistic.Providers;

public class ProviderDto
{
    [Required(ErrorMessage = "The code can't be empty")]
    public string Code { get; set; } = string.Empty;
    [Required(ErrorMessage = "The name can't be empty")]
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;

    public List<PurchaseDto>? Purchases { get; set; } = [];
}
