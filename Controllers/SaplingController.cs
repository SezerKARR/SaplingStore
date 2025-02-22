using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaplingStore.Abstract;
using SaplingStore.DTOs.SaplingDTO;
using SaplingStore.Interfaces;
using SaplingStore.Models;

namespace SaplingStore.Controllers;

using Repository;

[Route("api/[controller]")]
[ApiController]
public class SaplingController(
    IMapper mapper,
    SaplingRepository saplingRepository,
    SaplingCategoryRepository saplingCategoryRepository)
    : BaseController<SaplingRepository, Sapling, SaplingReadDto, SaplingUpdateDto, SaplingCreateDto>(mapper,
        saplingRepository)
{
    protected override async Task<IActionResult?> AddError(SaplingCreateDto createDto) {
        if (!await saplingCategoryRepository.EntityExists(createDto.SaplingCategoryId))
            return BadRequest("saplingCategory does not exist");
        return await base.AddError(createDto);
    }
}