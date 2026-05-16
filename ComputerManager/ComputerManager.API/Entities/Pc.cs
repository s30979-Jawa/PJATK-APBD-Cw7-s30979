using System.ComponentModel.DataAnnotations;

namespace ComputerManager.API.Entities;

public class Pc
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
    
    public ICollection<PcComponent> Components { get; set; } = new List<PcComponent>();
}