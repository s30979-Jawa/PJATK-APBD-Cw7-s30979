using ComputerManager.API.DTOs;

namespace ComputerManager.API.Services;

public interface IPcService
{
    Task<IEnumerable<PcGetAllDto>> GetAllAsync();
    Task<PcGetByIdDto?> GetByIdAsync(int id);
    Task<PcGetAllDto> CreateAsync(PcCreateDto dto);
    Task<bool> UpdateAsync(int id, PcUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}