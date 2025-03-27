using System.ComponentModel.DataAnnotations.Schema;
using RulerHub.Shared.Entities.Abstractions;

namespace RulerHub.Shared.Entities.Logistic;

public class ReturnItem : Entity
{
    public int IdReturn { get; set; }

    [Column(TypeName = "decimal(8, 5)")]
    public decimal Amount { get; set; }
    [Column(TypeName = "decimal(8, 2)")]
    public decimal Price { get; set; }

    public DateTime ReturnDate { get; set; } = DateTime.Now;
}