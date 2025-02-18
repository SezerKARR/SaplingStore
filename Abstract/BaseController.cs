using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaplingStore.Helpers;
using SaplingStore.Interfaces;

namespace SaplingStore.Abstract;

public abstract class BaseController<T, TEntity, TReadDto, TUpdateDto, TCreateDto> : Controller, IController<TUpdateDto>
    where T : class, IClassRepository<TEntity>
    where TEntity : class, IEntity
    where TReadDto : class, IReadDto
    where TUpdateDto : class, IUpdateDto
    where TCreateDto : class, ICreateDto
{
    protected readonly T _genericRepository;
    protected readonly IMapper _mapper;

    protected BaseController(IMapper mapper, T genericRepository)
    {
        _genericRepository = genericRepository;
        _mapper = mapper;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByEntityId([FromRoute] int id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var entityModel = await _genericRepository.GetByIdAsync(id);
        if (entityModel == null) return NotFound();
        return Ok(_mapper.Map<TReadDto>(entityModel));
    }

// Slug ile arama yapan metod
    [HttpGet("{slug}")]
    public async Task<IActionResult> GetBySlug([FromRoute] string slug)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var entityModel = await _genericRepository.GetBySlugAsync(slug);
        if (entityModel == null) return NotFound();
        return Ok(_mapper.Map<TReadDto>(entityModel));
    }

    // [Authorize(Roles = "Admin")]
    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id,
        [FromBody] TUpdateDto updateDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var entityModel = await _genericRepository.UpdateAsync(id, updateDto);

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

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TCreateDto createDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var errorResult = await AddError(createDto);
        if (errorResult != null)
            return errorResult;
        
        var entity = _mapper.Map<TEntity>(createDto);
        entity.Slug = SlugHelper.GenerateSlug(entity.Name);
        try
        {
            await _genericRepository.CreateAsync(entity);
        }
        catch (Exception ex)
        {
            // Log the exception
            return StatusCode(500, ex+"Internal server error");
        }
        var asd = _mapper.Map<TReadDto>(entity);
        return CreatedAtAction(nameof(GetByEntityId), new { id = entity.Id },
            asd);
    }

    protected virtual async Task<IActionResult?> AddError(TCreateDto createDto)
    {
        return await Task.FromResult<IActionResult?>(null);
    }


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

        List<TEntity> entities = await _genericRepository.GetAllAsync(queryObject);
        List<TReadDto> readDtos = entities.Select(entity => _mapper.Map<TReadDto>(entity)).ToList();
        return Ok(readDtos);
    }
}