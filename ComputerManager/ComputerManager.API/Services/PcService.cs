using ComputerManager.API.Data;
using ComputerManager.API.DTOs;
using ComputerManager.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComputerManager.API.Services;

public class PcService : IPcService
{
    private readonly AppDbContext _context;
    
    public PcService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<PcGetAllDto>> GetAllAsync()
    {
        return await _context.Pcs
            .Select(pc => new PcGetAllDto
            {
                Id = pc.Id,
                Name = pc.Name,
                Weight = pc.Weight,
                Warranty = pc.Warranty,
                CreatedAt = pc.CreatedAt,
                Stock = pc.Stock
            })
            .ToListAsync();
    }

    public async Task<PcGetByIdDto?> GetByIdAsync(int id)
    {
        var pc = await _context.Pcs
            .Include(p => p.Components)
            .ThenInclude(pc => pc.Component)
            .ThenInclude(c => c.Manufacturer)
            .Include(p => p.Components)
            .ThenInclude(pc => pc.Component)
            .ThenInclude(c => c.Type)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (pc == null) return null;

        return new PcGetByIdDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock,
            Components = pc.Components.Select(c => new PcComponentDto
            {
                Amount = c.Amount,
                Component = new ComponentDto
                {
                    Code = c.Component.Code,
                    Name = c.Component.Name,
                    Description = c.Component.Description,
                    Manufacturer = new ComponentManufacturerDto
                    {
                        Id = c.Component.Manufacturer.Id,
                        Abbreviation = c.Component.Manufacturer.Abbreviation,
                        FullName = c.Component.Manufacturer.FullName,
                        FoundationDate = c.Component.Manufacturer.FoundationDate
                    },
                    Type = new ComponentTypeDto
                    {
                        Id = c.Component.Type.Id,
                        Abbreviation = c.Component.Type.Abbreviation,
                        Name = c.Component.Type.Name
                    }
                }
            }).ToList()
        };
    }

    public async Task<PcGetAllDto> CreateAsync(PcCreateDto dto)
    {
        var pc = new Pc
        {
            Name = dto.Name,
            Weight = dto.Weight,
            Warranty = dto.Warranty,
            CreatedAt = dto.CreatedAt,
            Stock = dto.Stock
        };
        
        _context.Pcs.Add(pc);
        await _context.SaveChangesAsync();

        return new PcGetAllDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task<bool> UpdateAsync(int id, PcUpdateDto dto)
    {
        var pc = await _context.Pcs.FindAsync(id);
        
        if (pc == null) return false;
        
        pc.Name = dto.Name;
        pc.Weight = dto.Weight;
        pc.Warranty = dto.Warranty;
        pc.CreatedAt = dto.CreatedAt;
        pc.Stock = dto.Stock;
        
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var pc = await _context.Pcs.FindAsync(id);

        if (pc == null) return false;

        _context.Pcs.Remove(pc);
        await _context.SaveChangesAsync();
        return true;
    }
}