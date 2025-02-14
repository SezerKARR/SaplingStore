using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaplingStore.Abstract;
using SaplingStore.DTOs.SaplingDTO;
using SaplingStore.DTOs.SaplingHeightDto;
using SaplingStore.Interfaces;
using SaplingStore.Models;

namespace SaplingStore.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SaplingHeightController(
    IMapper mapper,
    IClassRepository<SaplingHeight> saplingHeightRepository,
    IClassRepository<Sapling> saplingRepository)
    : BaseController<IClassRepository<SaplingHeight>, SaplingHeight, SaplingHeightReadDto, SaplingHeightUpdateDto, SaplingHeightCreateDto>(mapper,
        saplingHeightRepository)
{
    protected override async Task<IActionResult?> AddError(SaplingHeightCreateDto createDto)
    {
        if (!await saplingRepository.EntityExists(createDto.SaplingId))
            return BadRequest("sapling does not exist");
        return await base.AddError(createDto);
    }
}