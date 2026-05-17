using ComputerManager.API.DTOs;
using ComputerManager.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComputerManager.API.Controllers;

[ApiController]
[Route("api/pcs")]
public class PcsController : ControllerBase
{
    private readonly IPcService _pcService;

    public PcsController(IPcService pcService)
    {
        _pcService = pcService;
    }
    
    //metody, get, post, itp.
    
    //GET api/pcs
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var pcs = await _pcService.GetAllAsync();
        return Ok(pcs);
    }

    //GET api/pcs/{id}/components
    [HttpGet("{id}/components")]
    public async Task<IActionResult> GetById(int id)
    {
        var pc = await _pcService.GetByIdAsync(id);
        if (pc == null) return NotFound();
        return Ok(pc);
    }
    
    //POST api/pcs
    [HttpPost]
    public async Task<IActionResult> Create(PcCreateDto dto)
    {
        var pc = await _pcService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = pc.Id }, pc);
    }
    
    //PUT api/pcs/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, PcUpdateDto dto)
    {
        var result = await _pcService.UpdateAsync(id, dto);
        if (!result) return NotFound();
        return Ok();
    }
    
    //DELETE api/pcs/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _pcService.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}