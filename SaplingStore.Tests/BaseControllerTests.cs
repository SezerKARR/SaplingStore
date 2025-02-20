using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using SaplingStore.Abstract;
using SaplingStore.Controllers;
using SaplingStore.Data;
using SaplingStore.DTOs.SaplingDTO;
using SaplingStore.Mapper;
using SaplingStore.Models;
using SaplingStore.Repository;
using Xunit.Abstractions;

public class SaplingControllerTests
{
    readonly ITestOutputHelper _testOutputHelper;
    readonly IMapper _mapper;
    private readonly AppDbContext _context;
    readonly ClassRepository<Sapling> _saplingRepository;
    readonly ClassRepository<SaplingCategory> _saplingCategoryRepository;
    readonly SaplingController _saplingController;

    public SaplingControllerTests(ITestOutputHelper testOutputHelper)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase($"TestDatabase_{Guid.NewGuid()}")  // Farklı veritabanı adı
            .Options;

        var mockMapper = new Mock<IMapper>();
        _mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()).CreateMapper();
        _context = new AppDbContext(options);
        _saplingRepository = new SaplingRepository(_context, _mapper);
        _saplingCategoryRepository = new SaplingCategoryRepository(_context, _mapper);
        _saplingController = new SaplingController(_mapper, _saplingRepository, _saplingCategoryRepository);
    }

    // Test: SaplingCategory mevcutsa başarılı bir şekilde Sapling oluşturulmalı
    [Fact]
    public async Task Create_ReturnsCreatedAtAction_WhenSaplingCategoryExists()
    {
        // Arrange: SaplingCategory ekleniyor
        var saplingCategory = new SaplingCategory
        {
            ImageUrl = "",
            Slug = "",
            Id = 1,
            Name = "Trees"
        };

        _context.SaplingCategories.Add(saplingCategory);
        await _context.SaveChangesAsync();

        var createDto = new SaplingCreateDto
        {
            Name = "Oak Tree",
            SaplingCategoryId = 1,
            Id = 0,
            ImageUrl = ""// Geçerli SaplingCategoryId
            
        };

        // Act: Sapling oluşturuluyor
        var result = await _saplingController.Create(createDto);
        Console.WriteLine(result);
        // Assert: Sonuç başarıyla CreatedAtAction olmalı
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        var createdSapling = Assert.IsType<SaplingReadDto>(createdAtActionResult.Value);
        Assert.Equal("Oak Tree", createdSapling.Name);
    }

    // Test: SaplingCategory mevcut değilse BadRequest döndürmeli
    [Fact]
    public async Task Create_ReturnsBadRequest_WhenSaplingCategoryDoesNotExist()
    {
        // Arrange: Geçerli bir SaplingCategoryId kullanılmasına rağmen, böyle bir kategori yok
        var createDto = new SaplingCreateDto
        {
            Name = "Oak Tree",
            SaplingCategoryId = 99,
            Id = 0// Geçersiz SaplingCategoryId
        };

        // Act: Sapling oluşturulmaya çalışılıyor
        var result = await _saplingController.Create(createDto);

        // Assert: Sonuç BadRequest olmalı
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("saplingCategory does not exist", badRequestResult.Value);
    }
    [Fact]
    public async Task Update_ReturnsBadRequest_WhenModelStateIsInvalid()
    {
        // Arrange: ModelState geçersiz
        var invalidUpdateDto = new SaplingUpdateDto
        {
            Name = "Oak Tree",
            
            SaplingCategoryId = 1
        };

        _saplingController.ModelState.AddModelError("Name", "Name is required");

        // Act: Güncelleme yapılıyor
        var result = await _saplingController.Update(1, invalidUpdateDto);

        // Assert: Sonuç BadRequest olmalı
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Contains("Name is required", badRequestResult.Value.ToString());
    }
}
