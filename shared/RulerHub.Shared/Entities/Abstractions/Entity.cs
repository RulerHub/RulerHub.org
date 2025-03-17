namespace RulerHub.Shared.Entities.Abstractions;

public abstract class Entity
{
    public int Id { get; set; }
    public DateTime DateCreate { get; set; } = DateTime.Now;
    public DateTime? DateUpdate { get; set; }
}
