using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaplingStore.Abstract;
using SaplingStore.DTOs.SaplingCategory;
using SaplingStore.Interfaces;
using SaplingStore.Models;

namespace SaplingStore.Controllers;

using Repository;

[Route("api/[controller]")]
[ApiController]
public class SaplingCategoryController(IMapper mapper, SaplingCategoryRepository saplingCategoryRepository)
    : BaseController<SaplingCategoryRepository, SaplingCategory, SaplingCategoryReadDto,
        SaplingCategoryUpdateDto, SaplingCategoryCreateDto>(mapper, saplingCategoryRepository);