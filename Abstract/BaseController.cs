using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaplingStore.Helpers;
using SaplingStore.Interfaces;

namespace SaplingStore.Abstract;

using Microsoft.EntityFrameworkCore;

public abstract class BaseController<T, TEntity, TReadDto, TUpdateDto, TCreateDto>(IMapper mapper, T genericRepository,IWebHostEnvironment environment) : Controller
    where T : class, IClassRepository<TEntity>
    where TEntity : Entity
    where TReadDto : ReadDto
    where TUpdateDto : UpdateDto
    where TCreateDto : CreateDto {
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByEntityId([FromRoute] int id) {

        var entityModel = await genericRepository.GetByIdAsync(id);
        if (entityModel == null) return NotFound();
        return Ok(mapper.Map<TReadDto>(entityModel));
    }

// Slug ile arama yapan metod
    [HttpGet("{slug}")]
    public async Task<IActionResult> GetBySlug([FromRoute] string slug) {

        var entityModel = await genericRepository.GetBySlugAsync(slug);
        if (entityModel == null) return NotFound();
        return Ok(mapper.Map<TReadDto>(entityModel));
    }

    // [Authorize(Roles = "Admin")]
    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id,
        [FromBody] TUpdateDto updateDto) {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var entityModel = await genericRepository.UpdateAsync(id, updateDto);

        if (entityModel == null) return BadRequest($"{typeof(TEntity)} does not exist");


        return Ok(mapper.Map<TReadDto>(entityModel));
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id) {
        if (!ModelState.IsValid) return BadRequest(ModelState);


        var entityModel = await genericRepository.DeleteAsync(id);
        if (entityModel == null) return NotFound();
        return Ok(entityModel);
    }
    [HttpPost("with-file")]
    public async Task<IActionResult> CreateWithFile([FromForm] TCreateDto createDto, [FromForm] IFormFile file)
    {
        // 1️⃣ Önce JSON verisini işle (FromBody gibi hareket et)
        var response = await Create(createDto);

        if (response is CreatedAtActionResult createdActionResult)
        {
            var entity = (TEntity)createdActionResult.Value!;

            // 2️⃣ Dosya varsa kaydet
            if (file != null && file.Length > 0)
            {
                var filePath = await SaveFile(file);
                var updatedEntity = await UpdateFileField(entity, filePath);

                return Ok(updatedEntity);
            }

            return response;
        }

        return response;
    }
    protected abstract Task<TReadDto> UpdateFileField(TReadDto entity, string filePath);

    [HttpPost("without-file")]
    public async Task<IActionResult> CreateWithoutFile([FromBody] TCreateDto createDto)
    {
        return await Create(createDto);
    }
    protected async Task<IActionResult> Create(TCreateDto createDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var errorResult = await AddError(createDto);
        if (errorResult != null)
            return errorResult;

        var entity = mapper.Map<TEntity>(createDto);
        try
        {
            await genericRepository.CreateAsync(entity);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error: " + ex.Message);
        }

        var createdEntity = mapper.Map<TReadDto>(entity);
        return CreatedAtAction(nameof(GetByEntityId), new { id = entity.GetType().GetProperty("Id")?.GetValue(entity) }, createdEntity);
    }
    private async Task<string> SaveFile(IFormFile file)
    {
        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        var filePath = Path.Combine(environment.WebRootPath, "uploads", fileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        return Path.Combine("uploads", fileName);
    }
    public abstract  Task<IActionResult> AdjustFormFile([FromForm] IFormFile file);
    
   

    protected virtual async Task<IActionResult?> AddError(TCreateDto createDto) {
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
    public async Task<IActionResult> GetAllGenericEntity([FromQuery] QueryObject queryObject) {
        if (!ModelState.IsValid) return BadRequest(ModelState);
      
        List<TEntity> entities = await genericRepository.GetAllAsync(queryObject);
        List<TReadDto> readDtos = entities.Select(entity => mapper.Map<TReadDto>(entity)).ToList();
        return Ok(readDtos);
    }
}