using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaplingStore.Abstract;
using SaplingStore.Data;
using SaplingStore.DTOs;
using SaplingStore.DTOs.SaplingCategory;
using SaplingStore.DTOs.SaplingDTO;
using SaplingStore.Interfaces;
using SaplingStore.Mapper;
using SaplingStore.Models;

namespace SaplingStore.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SaplingCategoryController:Controller
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _appDbContext;
    private readonly IClassRepository<SaplingCategory> _saplingCategoryRepository;
    public SaplingCategoryController(IMapper mapper,AppDbContext appDbContext, IClassRepository<SaplingCategory> saplingCategoryRepository)
    {
        _mapper = mapper;
        _appDbContext = appDbContext;
        this._saplingCategoryRepository = saplingCategoryRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSaplingCategoryRequestDto saplingCategoryRequestDto)
    {
        var sablingCategoryModel =_mapper.Map<SaplingCategory>(saplingCategoryRequestDto);
        await _saplingCategoryRepository.CreateAsync(sablingCategoryModel);
        return CreatedAtAction(nameof(GetSaplingById), new { id = sablingCategoryModel.Id },
            _mapper.Map<SaplingCategoryDto>(sablingCategoryModel));
    }
    [HttpGet]
    public async Task<IActionResult> GetAllSaplings()
    {
        var saplings = await _saplingCategoryRepository.GetAllAsync();
       var saplingDtos = saplings.Select(s=>_mapper.Map<SaplingCategoryDto>(s));
       return Ok(saplingDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSaplingById([FromRoute] int id)
    {
        var sapling = await _saplingCategoryRepository.GetByIdAsync(id);
        if (sapling == null) return NotFound();
        return Ok(_mapper.Map<SaplingCategoryDto>(sapling));
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSaplingRequestDto updateSaplingRequestDto)
    {
        var saplingModel = await _saplingCategoryRepository.UpdateAsync(id, updateSaplingRequestDto);
        if (saplingModel == null) return NotFound();
        return Ok(_mapper.Map<SaplingCategoryDto>(saplingModel));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var saplingMoodel = await _saplingCategoryRepository.DeleteAsync(id);
        if (saplingMoodel == null) return NotFound();
        return NoContent();
    }
}
