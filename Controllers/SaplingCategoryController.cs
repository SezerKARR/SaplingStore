using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaplingStore.Abstract;
using SaplingStore.DTOs.SaplingCategory;
using SaplingStore.Interfaces;
using SaplingStore.Models;

namespace SaplingStore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SaplingCategoryController(IMapper mapper, IClassRepository<SaplingCategory> saplingCategoryRepository)
    : BaseController<IClassRepository<SaplingCategory>, SaplingCategory, SaplingCategoryReadDto,
        SaplingCategoryUpdateDto, SaplingCategoryCreateDto>(mapper, saplingCategoryRepository);