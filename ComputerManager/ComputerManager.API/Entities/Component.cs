using System.ComponentModel.DataAnnotations;

namespace ComputerManager.API.Entities;

public class Component
{
    [MaxLength(10)]
    [Key]
    public string Code { get; set; } = string.Empty;
    [MaxLength(300)]
    public string Name { get; set; }  = string.Empty;
    public string Description { get; set; }  = string.Empty;
    
    //klucz obcy
    public int ComponentManufacturerId { get; set; }
    public ComponentManufacturer Manufacturer { get; set; } = null!;
    
    public int ComponentTypeId { get; set; }
    public ComponentType Type { get; set; } = null!;

}