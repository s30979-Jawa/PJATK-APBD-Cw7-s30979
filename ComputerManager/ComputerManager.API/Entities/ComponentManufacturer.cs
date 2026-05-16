using System.ComponentModel.DataAnnotations;

namespace ComputerManager.API.Entities;

public class ComponentManufacturer
{
    public int Id { get; set; }
    [MaxLength(30)]
    public string Abbreviation { get; set; }  = string.Empty;
    [MaxLength(300)]
    public string FullName { get; set; }  = string.Empty;
    public DateOnly FoundationDate { get; set; }
}