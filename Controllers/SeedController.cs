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
        Dictionary<string,List<Object>> exportDatas = new Dictionary<string, List<Object>>();
        
        exportDatas.Add("sapling",await _seedDataGeneric.ExportData(_saplingRepository));
        exportDatas.Add("saplingHeight",await _seedDataGeneric.ExportData(_saplingHeightRepository));
        exportDatas.Add("saplingCategory",await _seedDataGeneric.ExportData(_saplingCategoryRepository));
        await _seedDataGeneric.ExportAll(exportDatas);
       
        return Ok();
        // Doğru bir şekilde IEnumerable<IClassRepository<IEntity>> koleksiyonu oluşturuluyor
        // İEntity türünü implement eden tüm repository'leri liste olarak alabilirsiniz
        // IEnumerable<IClassRepository<Entity>?> repositories = new List<IClassRepository<Entity>?>()
        // {
        //     _saplingRepository as IClassRepository<Entity>, 
        //     _saplingCategoryRepository as IClassRepository<IEntity>,
        //     _saplingHeightRepository as IClassRepository<IEntity>
        // };
        // await _seedDataGeneric.ExportAllData(_saplingRepository,);
        // Repository'leri ExportCurrentData metoduna geçiriyoruz
        // await  _seedDataGeneric.ExportAllData(repositories);
        // await _seedDataGeneric.ExportCurrentData<Sapling,SaplingCreateDto>(_saplingRepository);
        // await _seedDataGeneric.ExportCurrentData<SaplingCategory,SaplingCategoryCreateDto>(_saplingCategoryRepository);
        // await _seedDataGeneric.ExportCurrentData<SaplingHeight,SaplingHeightCreateDto>(_saplingHeightRepository);
    }
  
    // private async void CallExport<TEntity>(IClassRepository<TEntity>? repository)  where TEntity : class, IEntity {
    //     Type createDtoType = repository.GetCreateDto();
    //     await _seedDataGeneric.ExportData<createDtoType, TEntity>(repository);
    // }
    
}