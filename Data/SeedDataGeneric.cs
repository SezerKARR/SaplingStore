using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using SaplingStore.Interfaces;

namespace SaplingStore.Data
{
    using Abstract;
    using DTOs.SaplingDTO;
    using Models;
    using Repository;

    public class SeedDataGeneric
    {
        private readonly IMapper _mapper;

        public SeedDataGeneric(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        public async Task<List<Object>> ExportData<TEntity>(IClassRepository<TEntity> repository)   where TEntity : class,IEntity
        {
            var exportData = new Dictionary<string, object>();
            var data = await repository.GetAllAsync();
            var entityType = typeof(TEntity);// Repository'nin tuttuğu entity türü
            string name = entityType.Name;
            Type createDtoType = DtoTypesManager.GetCreateDtoType(name);
            var createDtos = new List<object>();
            foreach (var entity in data)
            {
                createDtos.Add(_mapper.Map(entity,typeof(TEntity),createDtoType));
            }
          
          

            // JSON'a çevir ve kaydet
            var json = JsonSerializer.Serialize(exportData, new JsonSerializerOptions { WriteIndented = true });

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", $"{name}.json");
            Directory.CreateDirectory(Path.GetDirectoryName(filePath)); // Eğer dizin yoksa oluştur
            await File.WriteAllTextAsync(filePath, json);
            return createDtos;
        }
        public async Task ExportAll(Dictionary<string, List<object>> exportDatas)
        {
            try
            {
                // Veriyi JSON formatına serileştir
                var json = JsonSerializer.Serialize(exportDatas, new JsonSerializerOptions
                {
                    WriteIndented = true, // JSON'ı daha okunabilir yapar
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull // Null değerleri dışarıda bırakır
                });

                // Dosya yolunu belirle
                string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
                string filePath = Path.Combine(directoryPath, "SeedData.json");

                // Dizini oluştur (eğer yoksa)
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // JSON verisini dosyaya yaz
                await File.WriteAllTextAsync(filePath, json);

                Console.WriteLine($"Data successfully exported to {filePath}");
            }
            catch (Exception ex)
            {
                // Hata durumunda loglama yap
                Console.Error.WriteLine($"An error occurred during data export: {ex.Message}");
                // Loglama veya hata yönetimi eklenebilir
            }
        }

        // public  async Task<List<TICreateDto>> GetAllCreateAsync<TEntity,TICreateDto>(IClassRepository<TEntity> repository)   where TEntity : class,IEntity 
        // where TICreateDto : ICreateDto {
        //     var all = await repository.GetAllAsync();
        //     var mappedEntities=new List<TICreateDto>();
        //     foreach (var entity in all)
        //     {
        //         mappedEntities.Add(_mapper.Map<TICreateDto>(entity));
        //     }
        //     return mappedEntities;
        //     // Entity'nin createDto tipini al ve mapperı kullan
        // }
        // public Task<List<TICreateDto>> ExportAdjust<TICreateDto>(Entity[] entities) where TICreateDto : ICreateDto {
        //     var exportData = new Dictionary<string, object>();
        //     var createCtos=new List<TICreateDto>();
        //     foreach (var entity in entities)
        //     {
        //         createCtos.Add(_mapper.Map<TICreateDto>(entity));
        //     }
        //     return Task.FromResult(createCtos);
        // }
        //
        //
        // public async Task ExportAllData<TEntity>(TEntity[] entities)
        // {
        //     var exportData = new Dictionary<string, object>();
        //
        //     foreach (var entity in entities)
        //     {
        //         
        //         var repoType = entity.GetType();
        //         var genericInterface = repoType.GetInterfaces()
        //             .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IClassRepository<>));
        //
        //         if (genericInterface != null)
        //         {
        //             Type entityType = genericInterface.GetGenericArguments()[0];
        //             var getAllMethod = repoType.GetMethod("GetAllAsync", Type.EmptyTypes);
        //
        //             if (getAllMethod != null)
        //             {
        //                 var task = (Task)getAllMethod.Invoke(entity, null);
        //                 await task;
        //
        //                 var resultProperty = task.GetType().GetProperty("Result");
        //                 var data = resultProperty.GetValue(task);
        //
        //                 var createDtoType = typeof(CreateDto);
        //                 var mapMethod = typeof(IMapper).GetMethod("Map", new[] { data.GetType() });
        //
        //                 if (mapMethod != null)
        //                 {
        //                     var mappedData = (IEnumerable<object>)mapMethod.Invoke(_mapper, new object[] { data });
        //                     exportData.Add(entityType.Name, mappedData);
        //                 }
        //             }
        //         }
        //     }
        //
        //     // JSON'a çevir ve kaydet
        //     var jsonOptions = new JsonSerializerOptions
        //     {
        //         WriteIndented = true,
        //         ReferenceHandler = ReferenceHandler.Preserve // Bu özellik döngüsel referansları düzgün işler
        //     };
        //
        //     var json = JsonSerializer.Serialize(exportData, jsonOptions);
        //     var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "SeedData.json");
        //     Directory.CreateDirectory(Path.GetDirectoryName(filePath)); // Eğer dizin yoksa oluştur
        //     await File.WriteAllTextAsync(filePath, json);
        // }
    }
}
