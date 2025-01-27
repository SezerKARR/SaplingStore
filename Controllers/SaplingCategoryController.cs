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
public class SaplingCategoryController(IMapper mapper, IClassRepository<SaplingCategory> saplingCategoryRepository)
    : BaseController<IClassRepository<SaplingCategory>, SaplingCategory, SaplingCategoryReadDto,
        SaplingCategoryUpdateDto, SaplingCategoryCreateDto>(mapper, saplingCategoryRepository);