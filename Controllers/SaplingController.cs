using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaplingStore.Abstract;
using SaplingStore.Data;
using SaplingStore.DTOs;
using SaplingStore.DTOs.SaplingDTO;
using SaplingStore.Interfaces;
using SaplingStore.Mapper;
using SaplingStore.Models;

namespace SaplingStore.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SaplingController:Controller
{
    private readonly IClassRepository<Sapling> _saplingRepository;
    private readonly IClassRepository<SaplingCategory> _saplingCategoryRepository;
    private readonly IMapper _mapper;

    public SaplingController(IMapper mapper ,IClassRepository<Sapling> saplingRepository,IClassRepository<SaplingCategory> saplingCategoryRepository)
    {
        _mapper = mapper;
        _saplingRepository = saplingRepository;
        _saplingCategoryRepository = saplingCategoryRepository;
    }
    [HttpPost("{saplingCategoryId}")]
    public async Task<IActionResult> Create([FromRoute] int saplingCategoryId,  CreateSaplingRequestDto saplingDto)
    {
        if (!await _saplingCategoryRepository.EntityExists(saplingCategoryId))
        {
            return BadRequest("Category does not exist");
        }
        
        var sablingModel = _mapper.Map<Sapling>(saplingDto);
        sablingModel.SaplingCategoryId = saplingCategoryId;
        await _saplingRepository.CreateAsync(sablingModel);
        return CreatedAtAction(nameof(GetSaplingById), new { id = sablingModel },
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

