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

[Route("sapling-store/sapling-category")]
[ApiController]
public class SaplingCategoryController : BaseController<IClassRepository<SaplingCategory>,SaplingCategory,SaplingCategoryReadDto,SaplingCategoryUpdateDto,SaplingCategoryCreateDto>
{
    public SaplingCategoryController(IMapper mapper, IClassRepository<SaplingCategory> saplingCategoryRepository) : base(mapper,saplingCategoryRepository)
    { }
    [HttpPost]
    public virtual async Task<IActionResult> Create(
        [FromBody] SaplingCategoryCreateDto categoryCreateDtoDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var entityModel = _mapper.Map<SaplingCategory>(categoryCreateDtoDto);
        await _genericRepository.CreateAsync(entityModel);
        return CreatedAtAction(nameof(GetByEntityId), new { id = entityModel.Id },
            _mapper.Map<SaplingCategoryReadDto>(entityModel));
    }
}