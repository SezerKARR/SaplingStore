using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using SaplingStore.Interfaces;

namespace SaplingStore.Data {
using System.Reflection;
using Abstract;
using DTOs.SaplingDTO;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository;

public class SeedDataGeneric {
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public SeedDataGeneric(IMapper mapper,AppDbContext dbContext, AppDbContext context) {
        _mapper = mapper;
        _context = context;
    }

    public async Task<List<Object>> ExportData<TEntity>(IClassRepository<TEntity> repository) where TEntity : class, IEntity {
        var exportData = new Dictionary<string, object>();
        var data = await repository.GetAllAsync();
        var entityType = typeof(TEntity);// Repository'nin tuttuğu entity türü
        string name = entityType.Name;
        Type createDtoType = DtoTypesManager.GetCreateDtoType(name);
        var createDtos = new List<object>();
        foreach (var entity in data) { createDtos.Add(_mapper.Map(entity, typeof(TEntity), createDtoType)); }


        // JSON'a çevir ve kaydet
        var json = JsonSerializer.Serialize(exportData, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", $"{name}.json");
        Directory.CreateDirectory(Path.GetDirectoryName(filePath));// Eğer dizin yoksa oluştur
        await File.WriteAllTextAsync(filePath, json);
        return createDtos;
    }
    public async Task ExportAll(Dictionary<Type, List<object>> exportDatas) {
        try
        {
            // Veriyi JSON formatına serileştir
            var json = JsonSerializer.Serialize(exportDatas, new JsonSerializerOptions
            {
                WriteIndented = true,// JSON'ı daha okunabilir yapar
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull// Null değerleri dışarıda bırakır
            });

            // Dosya yolunu belirle
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string filePath = Path.Combine(directoryPath, "SeedData.json");

            // Dizini oluştur (eğer yoksa)
            if (!Directory.Exists(directoryPath)) { Directory.CreateDirectory(directoryPath); }

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
}
}