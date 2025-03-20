using RulerHub.Shared.Entities.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

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