using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaplingStore.Abstract;
using SaplingStore.Data;
using SaplingStore.DTOs;
using SaplingStore.DTOs.Sapling;
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
    private readonly IMapper _mapper;

    public SaplingController(IMapper mapper,AppDbContext appDbContext, IClassRepository<Sapling> saplingRepository)
    {
        _mapper = mapper;
        _appDbContext = appDbContext;
        _saplingRepository = saplingRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSaplingRequestDto saplingDto)
    {
        var sablingModel = _mapper.Map<Sapling>(saplingDto);
        await _saplingRepository.CreateAsync(sablingModel);
        return CreatedAtAction(nameof(GetSaplingById), new { id = sablingModel.Id },
            _mapper.Map<SaplingDto>(sablingModel));
    }
    [HttpGet]
    public async Task<IActionResult> GetAllSaplings()
    {
        var saplings = await _saplingRepository.GetAllAsync();
       var saplingDtos = saplings.Select(s=>_mapper.Map<SaplingDto>(s));
       return Ok(saplingDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSaplingById([FromRoute] int id)
    {
        var sapling = await _saplingRepository.GetByIdAsync(id);
        if (sapling == null) return NotFound();
        return Ok(_mapper.Map<SaplingDto>(sapling));
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSaplingRequestDto updateSaplingRequestDto)
    {
        var saplingModel = await _saplingRepository.UpdateAsync(id, updateSaplingRequestDto);
        if (saplingModel == null) return NotFound();
        return Ok(_mapper.Map<SaplingDto>(saplingModel));
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

