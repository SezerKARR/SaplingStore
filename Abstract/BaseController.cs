using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaplingStore.DTOs.SaplingCategory;
using SaplingStore.Helpers;
using SaplingStore.Interfaces;
using SaplingStore.Models;

namespace SaplingStore.Abstract;

public abstract class BaseController<T, TEntity, TReadDto, TUpdateDto, TCreateDto>(IMapper mapper, T genericRepository)
    : Controller, IController<TUpdateDto>
    where T : class, IClassRepository<TEntity>
    where TEntity : class, IEntity
    where TReadDto : class, IReadDto
    where TUpdateDto : class, IUpdateDto
    where TCreateDto : class, ICreateDto
{
    protected readonly IMapper _mapper = mapper;
    protected readonly T _genericRepository = genericRepository;

    

    // [HttpGet]
    // public async Task<IActionResult> GetAllGenericEntity()
    // {
    //     if (!ModelState.IsValid) return BadRequest(ModelState);
    //
    //     List<TEntity> saplings = await _genericRepository.GetAllAsync();
    //     List<TReadDto>
    //         saplingDtos = saplings.Select(s => _mapper.Map<TReadDto>(s)).ToList();
    //     return Ok(saplingDtos);
    // }
    [HttpGet]
    public async Task<IActionResult> GetAllGenericEntity([FromQuery] QueryObject queryObject)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        List<TEntity> saplings = await _genericRepository.GetAllAsync(queryObject);
        List<TReadDto>
            saplingDtos = saplings.Select(s => _mapper.Map<TReadDto>(s)).ToList();
        return Ok(saplingDtos);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByEntityId([FromRoute] int id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        TEntity? entityModel = await _genericRepository.GetByIdAsync(id);
        if (entityModel == null) return NotFound();
        return Ok(_mapper.Map<TReadDto>(entityModel));
    }

   


    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id,
        [FromBody] TUpdateDto updateDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        TEntity? entityModel = await _genericRepository.UpdateAsync(id, updateDto);
        if (entityModel == null) return NotFound();
        return Ok(_mapper.Map<TReadDto>(entityModel));
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);


        var entityModel = await _genericRepository.DeleteAsync(id);
        if (entityModel == null) return NotFound();
        return Ok(entityModel);
    }
}