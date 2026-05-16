using System.ComponentModel.DataAnnotations;

namespace ComputerManager.API.Entities;

public class PcComponent
{
    public int Amount { get; set; }
    
    public int PcId { get; set; }
    public Pc Pc { get; set; } = null!;
    
    [MaxLength(10)]
    public string ComponentCode { get; set; } = string.Empty;
    public Component Component { get; set; } = null!;

}