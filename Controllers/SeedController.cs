namespace SaplingStore.Controllers;

using Abstract;
using Data;
using DTOs.SaplingCategory;
using DTOs.SaplingDTO;
using DTOs.SaplingHeightDto;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;

[Route("api/[controller]")]
[ApiController]
public class SeedController(SaplingRepository saplingRepository, SaplingCategoryRepository saplingCategoryRepository, 
    SaplingHeightRepository saplingHeightRepository, SeedDataGeneric seedDataGeneric)
    : Controller {
    readonly SaplingRepository _saplingRepository = saplingRepository;
    readonly SaplingCategoryRepository _saplingCategoryRepository = saplingCategoryRepository;
    readonly  SaplingHeightRepository _saplingHeightRepository = saplingHeightRepository;
    // readonly IClassRepository<Image> _imageRepository = imageRepository;
    private readonly SeedDataGeneric _seedDataGeneric = seedDataGeneric;
    [HttpPost]
    public async Task<IActionResult> ExportData()
    {
       
        // Repository'leri ExportCurrentData metoduna geçiriyoruz
        await _seedDataGeneric.ExportCurrentData<Sapling,SaplingCreateDto>(_saplingRepository);
        await _seedDataGeneric.ExportCurrentData<SaplingCategory,SaplingCategoryCreateDto>(_saplingCategoryRepository);
        await _seedDataGeneric.ExportCurrentData<SaplingHeight,SaplingHeightCreateDto>(_saplingHeightRepository);
        return Ok();
    }
}