using System.ComponentModel.DataAnnotations.Schema;
using RulerHub.Shared.Entities.Abstractions;

namespace RulerHub.Shared.Entities.Logistic;

public class Return : Entity
{
    public int PurchaseId { get; set; }

    public string Code { get; set; } = string.Empty;
    public DateTime ReturnDate { get; set; }
    [Column(TypeName = "decimal(8, 2)")]
    public decimal TotalPrice { get; set; }

    public int? ProviderId { get; set; }
    public Provider? Provider { get; set; }

    public List<ReturnItem> ReturnItems { get; set; } = [];
}
