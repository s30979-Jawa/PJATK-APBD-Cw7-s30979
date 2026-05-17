using ComputerManager.API.Data;
using ComputerManager.API.DTOs;
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

    public Task<PcGetByIdDto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PcGetAllDto> CreateAsync(PcCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(int id, PcUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}