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
using SaplingStore.Repository;

namespace SaplingStore.Controllers;

[Route("sapling-store/sapling")]
[ApiController]
public class SaplingController(
    IMapper mapper,
    IClassRepository<Sapling> saplingRepository,
    IClassRepository<SaplingCategory> saplingCategoryRepository)
    : BaseController<IClassRepository<Sapling>, Sapling, SaplingReadDto, SaplingUpdateDto, SaplingCreateDto>(mapper, saplingRepository)
{
    [HttpPost("{saplingCategoryId:int}")]
    public async Task<IActionResult> Create([FromRoute] int saplingCategoryId, SaplingCreateDto saplingCreateReadDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        if (!await saplingCategoryRepository.EntityExists(saplingCategoryId))
        {
            return BadRequest("Category does not exist");
        }

        Sapling? saplingModel = _mapper.Map<Sapling>(saplingCreateReadDto);
        saplingModel.SaplingCategoryId = saplingCategoryId;
        await _genericRepository.CreateAsync(saplingModel);
        SaplingReadDto asd = _mapper.Map<SaplingReadDto>(saplingModel);
        return CreatedAtAction(nameof(GetByEntityId), new { id = saplingModel.Id },
            asd);
    }

    
}