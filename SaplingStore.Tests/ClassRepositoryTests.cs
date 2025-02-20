//
// namespace SaplingStore.Tests.SaplingStore.Tests;
//
// using System;
// using System.Threading.Tasks;
// using Abstract;
// using AutoMapper;
// using Data;
// using Mapper;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
// using Models;
// using Moq;
// using Repository;
// using Xunit;
// using Xunit.Sdk;
//
// [Collection("NonParallelTests")]
// public class ClassRepositoryTests
// {
//     private readonly AppDbContext _context;
//     private readonly FakeClassRepository<TestEntity> _repository;
//     public ClassRepositoryTests()
//     {
//         // Her test için farklı bir InMemory veritabanı kullanıyoruz
//         var serviceProvider = new ServiceCollection()
//             .AddDbContext<AppDbContext>(options =>
//                 options.UseInMemoryDatabase("TestDatabase"))
//             .BuildServiceProvider();
//
//         _context = serviceProvider.GetRequiredService<AppDbContext>();
//
//         var mockMapper = new Mock<IMapper>();
//         _repository = new FakeClassRepository<TestEntity>(_context, mockMapper.Object);// Repository'yi doğru başlatıyoruz
//     }
//
//     [Fact]
//     public async Task CreateAsync_ShouldCreateEntity() {
//         _context.Database.EnsureDeleted();
//         _context.Database.EnsureCreated();
//         var sapling = new TestEntity
//         {
//             Name = "Oak Tree",
//             Slug = "slug",
//             Id = 1,
//
//         };
//         var createdSapling = await _repository.CreateAsync(sapling);
//         Assert.NotNull(createdSapling);
//         Assert.Equal("Oak Tree", createdSapling.Name);
//     }
//
//     [Fact]
//     public async Task EntityExists_ShouldReturnTrue_IfEntityExists() {
//         var sapling = new TestEntity
//         {
//             Name = "Sapling",
//             Slug = "slug",
//             Id = 1,
//         };
//         
//         
//             
//     
//         await _repository.CreateAsync(sapling);
//         bool exists = await _repository.EntityExists(1);
//         Assert.True(exists);
//     }
//
//     [Fact]
//     public async Task DeleteAsync_ShouldRemoveEntity() {
//         var sapling = new TestEntity
//         {
//             Name = "Sapling",
//             Slug = "slug",
//             Id = 1,
//         };
//         await _repository.CreateAsync(sapling);
//         await _repository.DeleteAsync(1);
//         bool existsAfterDelete = await _repository.EntityExists(1);
//         Assert.False(existsAfterDelete);
//     }
// }

namespace SaplingStore.Tests.SaplingStore.Tests;

using System;
using System.Threading.Tasks;
using Abstract;
using AutoMapper;
using Data;
using Mapper;
using Microsoft.EntityFrameworkCore;
using Models;
using Moq;
using Repository;
using Xunit;

[Collection("NonParallelTests")]
public class ClassRepositoryTests
{
    private readonly AppDbContext _context;
    private readonly ClassRepository<Sapling> _repository;
    private readonly IMapper _mapper;
    public ClassRepositoryTests()
    {
        // Her test için farklı bir InMemory veritabanı kullanıyoruz
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase($"TestDatabase_{Guid.NewGuid()}")  // Farklı veritabanı adı
            .Options;

        var mockMapper = new Mock<IMapper>();
        _mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()).CreateMapper();
        _context = new AppDbContext(options);  // DbContext'i doğru başlatıyoruz
        _repository = new SaplingRepository(_context, _mapper);// Repository'yi doğru başlatıyoruz
    }

    [Fact]
    public async Task CreateAsync_ShouldCreateEntity() {
        var sapling = new Sapling
        {
            Name = "Oak Tree",
            Slug = "slug",
            Id = 1,
            SaplingCategoryId = 0,
            ImageUrl = "a"

        };
        var createdSapling = await _repository.CreateAsync(sapling);
        Assert.NotNull(createdSapling);
        Assert.Equal("Oak Tree", createdSapling.Name);
    }

    [Fact]
    public async Task EntityExists_ShouldReturnTrue_IfEntityExists() {
        var sapling = new Sapling
        {
            Name = "Oak Tree",
            Slug = "slug",
            Id = 1,
            SaplingCategoryId = 0,
            ImageUrl = "a"
        };
        
        
            
    
        await _repository.CreateAsync(sapling);
        bool exists = await _repository.EntityExists(1);
        Assert.True(exists);
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveEntity() {
        var sapling = new Sapling
        {
            Name = "Oak Tree",
            Slug = "slug",
            Id = 1,
            SaplingCategoryId = 0,
            ImageUrl = "a"
        };
        await _repository.CreateAsync(sapling);
        await _repository.DeleteAsync(1);
        bool existsAfterDelete = await _repository.EntityExists(1);
        Assert.False(existsAfterDelete);
    }
}
