using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using SaplingStore.Interfaces;

namespace SaplingStore.Data;

using Abstract;
using Models;
using Repository;

public class SeedDataGeneric(IMapper mapper) {

    public async Task ExportCurrentData<TEntity,TCreateDto>(IClassRepository<TEntity> repository) where TEntity : class, IEntity where TCreateDto : CreateDto
    {
        var exportData = new Dictionary<string, object[]>();
        string name = typeof(TEntity).Name;
        var repoType = repository.GetType();
        var genericInterface = repoType.GetInterfaces()
            .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IClassRepository<>));

        if (genericInterface != null)
        {
            var datasa = repository.GetAllAsync();
            
           

            if (datasa.Result.Count>0)
                
            { 
                var mm=new Object[datasa.Result.Count];
                int i=0;
                foreach (var item in datasa.Result)
                {
                     mm[i]=mapper.Map<TCreateDto>(item);
                     i++;
                }
                exportData.Add(name, mm);

            }
        }


        // JSON'a çevir ve kaydet
        var jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.Preserve // Bu özellik döngüsel referansları düzgün işler
        };

        var json = JsonSerializer.Serialize(exportData, jsonOptions);

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", name+".json");
        Directory.CreateDirectory(Path.GetDirectoryName(filePath)); // Eğer dizin yoksa oluştur
        await File.WriteAllTextAsync(filePath, json);
    }

}