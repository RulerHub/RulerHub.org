using System.ComponentModel.DataAnnotations.Schema;
using RulerHub.Shared.Entities.Abstractions;

namespace RulerHub.Shared.Entities.Logistic;

public class Purchase : Entity
{
    public string Code { get; set; } = string.Empty;

    public DateTime PurchaseDate { get; set; }
    [Column(TypeName = "decimal(8, 2)")]
    public decimal TotalPrice { get; set; }

    public int? ProviderId { get; set; }
    public Provider? Provider { get; set; }

    public List<PurchaseItem> PurchaseItems { get; set; } = [];

    public bool IsActive { get; set; }
    public bool ItsPaid { get; set; }
}
