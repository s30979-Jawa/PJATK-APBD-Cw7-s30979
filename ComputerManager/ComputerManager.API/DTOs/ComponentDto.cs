namespace ComputerManager.API.DTOs;

public class ComponentDto
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ComponentTypeDto Type { get; set; } = null!;
    public ComponentManufacturerDto Manufacturer { get; set; } = null!;
}