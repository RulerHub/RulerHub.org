using System.ComponentModel.DataAnnotations.Schema;
using RulerHub.Shared.Entities.Abstractions;

namespace RulerHub.Shared.Entities.Logistic;

public class PurchaseItem : Entity
{
    public int IdPurchase { get; set; }

    [Column(TypeName = "decimal(8, 5)")]
    public decimal Amount { get; set; }
    [Column(TypeName = "decimal(8, 2)")]
    public decimal Price { get; set; }

    public DateTime PurchaseDate { get; set; } = DateTime.Now;
}