using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaplingStore.Abstract;
using SaplingStore.DTOs.SaplingDTO;
using SaplingStore.Interfaces;
using SaplingStore.Models;

namespace SaplingStore.Controllers;

[Route("sapling-store/sapling")]
[ApiController]
public class SaplingController(
    IMapper mapper,
    IClassRepository<Sapling> saplingRepository,
    IClassRepository<SaplingCategory> saplingCategoryRepository)
    : BaseController<IClassRepository<Sapling>, Sapling, SaplingReadDto, SaplingUpdateDto, SaplingCreateDto>(mapper, saplingRepository)
{
    

    protected override async Task<IActionResult?> AddError(SaplingCreateDto createDto)
    {
        if (!await saplingCategoryRepository.EntityExists(createDto.SaplingCategoryId))
        {
            return BadRequest("saplingCategory does not exist");
        }
        return await base.AddError(createDto);
    }

    


  
}