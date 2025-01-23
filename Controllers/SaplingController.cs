using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaplingStore.Data;
using SaplingStore.Dtos;
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
    public SaplingController(AppDbContext appDbContext,IClassRepository<Sapling> repository, IClassRepository<Sapling> saplingRepository)
    {
        _appDbContext = appDbContext;
        _saplingRepository = saplingRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSaplingRequestDto saplingDto)
    {
        var sablingModel = saplingDto.ToSaplingFromCreateDto();
        await _appDbContext.Saplings.AddAsync(sablingModel);
        await _appDbContext.SaveChangesAsync();
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
        var sapling = await _appDbContext.Saplings.FindAsync(id);
        if (sapling == null) return NotFound();
        return Ok(sapling.ToSaplingDto());
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSablingRequestDto updateSablingRequestDto)
    { 
        var saplingModel = await _appDbContext.Saplings.FirstOrDefaultAsync(x=>x.Id == id);
        if (saplingModel == null) return NotFound();
        saplingModel.Name = updateSablingRequestDto.Name;
        saplingModel.Heights = updateSablingRequestDto.Heights;
        _appDbContext.SaveChanges();
        return Ok(saplingModel.ToSaplingDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var saplingMoodel = await _appDbContext.Saplings.FirstOrDefaultAsync(x => x.Id == id);
        if (saplingMoodel == null) return NotFound();
        _appDbContext.Saplings.Remove(saplingMoodel);
        await _appDbContext.SaveChangesAsync();
        return NoContent();
    }
}

