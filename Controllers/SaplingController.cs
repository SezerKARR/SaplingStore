using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaplingStore.Abstract;
using SaplingStore.Data;
using SaplingStore.DTOs;
using SaplingStore.Interfaces;
using SaplingStore.Mapper;
using SaplingStore.Models;

namespace SaplingStore.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SaplingController:Controller
{
    private readonly AppDbContext _appDbContext;
    private readonly IClassRepository<Sapling> _saplingRepository;
    public SaplingController(AppDbContext appDbContext, IClassRepository<Sapling> saplingRepository)
    {
        _appDbContext = appDbContext;
        _saplingRepository = saplingRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSaplingRequestDto saplingDto)
    {
        var sablingModel = saplingDto.ToSaplingFromCreateDto();
        await _saplingRepository.CreateAsync(sablingModel);
        return CreatedAtAction(nameof(GetSaplingById), new { id = sablingModel.Id },
            sablingModel.ToSaplingDto());
    }
    [HttpGet]
    public async Task<IActionResult> GetAllSaplings()
    {
        var saplings = await _saplingRepository.GetAllAsync();
       var saplingDtos = saplings.Select(s=>s.ToSaplingDto());
       return Ok(saplingDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSaplingById([FromRoute] int id)
    {
        var sapling = await _saplingRepository.GetByIdAsync(id);
        if (sapling == null) return NotFound();
        return Ok(sapling.ToSaplingDto());
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSablingRequestDto updateSablingRequestDto)
    {
        var saplingModel = await _saplingRepository.UpdateAsync(id, updateSablingRequestDto);
        if (saplingModel == null) return NotFound();
        return Ok(saplingModel.ToSaplingDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var saplingMoodel = await _saplingRepository.DeleteAsync(id);
        if (saplingMoodel == null) return NotFound();
        return NoContent();
    }
}

