namespace SaplingStore.Controllers;

using Abstract;using AutoMapper;
using DTOs.Image;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;

[Route("api/[controller]")]
[ApiController]
public class ImageController(IMapper mapper, ImageRepository imageRepository) : 
    BaseController<ImageRepository, Image,ImageReadDto,ImageUpdateDto,ImageCreateDto>(mapper,imageRepository)
{

} 
// private readonly AppDbContext _context;
// [Route("api/[controller]")]
// [ApiController]
// public class SaplingCategoryController(IMapper mapper, IClassRepository<SaplingCategory> saplingCategoryRepository)
//     : BaseController<IClassRepository<SaplingCategory>, SaplingCategory, SaplingCategoryReadDto,
//         SaplingCategoryUpdateDto, SaplingCategoryCreateDto>(mapper, saplingCategoryRepository);
// {
    //
    // public ImageController(AppDbContext context)
    // {
    //     _context = context;
    // }
    //
    // [HttpPost]
    // public async Task<IActionResult> UploadImage(IFormFile file)
    // {
    //     if (file == null || file.Length == 0)
    //         return BadRequest("Dosya yüklenmedi");
    //
    //     if (!file.ContentType.StartsWith("image/"))
    //         return BadRequest("Dosya bir resim olmalı");
    //
    //     using (var memoryStream = new MemoryStream())
    //     {
    //         await file.CopyToAsync(memoryStream);
    //
    //         var image = new Image
    //         {
    //             Name = file.FileName,
    //             ImageData = memoryStream.ToArray(),
    //             ContentType = file.ContentType,
    //             UploadDate = DateTime.Now
    //         };
    //
    //         _context.Images.Add(image);
    //         await _context.SaveChangesAsync();
    //
    //         return Ok(new { id = image.Id });
    //     }
    // }
    //
    // [HttpGet]
    // public async Task<IActionResult> GetImage(int id)
    // {
    //     var image = await _context.Images.FindAsync(id);
    //
    //     if (image == null)
    //         return NotFound("Resim bulunamadı");
    //
    //     return File(image.ImageData, image.ContentType);
    // }}

