using System.Text.Json;
using SaplingStore.Interfaces;
using SaplingStore.Models;

namespace SaplingStore.Data;

public class DataImporter
{
    private readonly IClassRepository<SaplingCategory> _saplingCategoryRepository;
    private readonly IClassRepository<Sapling> _saplingRepository;
    private readonly IClassRepository<SaplingHeight> _saplingHeightRepository;
    private readonly Dictionary<string, object> _repositories;

  
    public DataImporter(IClassRepository<SaplingCategory> saplingCategoryRepository,
        IClassRepository<Sapling> saplingRepository,
        IClassRepository<SaplingHeight> saplingHeightRepository)
    {
        _saplingCategoryRepository = saplingCategoryRepository;
        _saplingRepository = saplingRepository;
        _saplingHeightRepository = saplingHeightRepository;
        _repositories = new Dictionary<string, object>
        {
            { "SaplingCategory", saplingCategoryRepository },
            { "Sapling", saplingRepository },
            { "SaplingHeight", saplingHeightRepository }
        };
    }

    public async Task ImportData()
    {
        string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        string filePath = Path.Combine(directoryPath, "SeedData.json");

        // If the file does not exist, terminate the process
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No data file found to import.");
            return;
        }

        // Read the JSON file
        string json = await File.ReadAllTextAsync(filePath);

        // Deserialize the JSON (Dynamic Object usage might be required)
        var importDatas = JsonSerializer.Deserialize<Dictionary<string, List<JsonElement>>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (importDatas == null || importDatas.Count == 0)
        {
            Console.WriteLine("No data found in the file.");
            return;
        }
        
        // Define the order of creation
        var creationOrder = DtoTypesManager.GetEntities();

        // Create objects in the specified order
        foreach (var key in creationOrder)
        {
            if (importDatas.ContainsKey(key))
            {
                foreach (var item in importDatas[key])
                {
                    // Assuming CreateObjectAsync is a method that creates an object from JsonElement
                    await CreateObjectAsync(key, item);
                }
            }
        }
    }

    public async Task CreateObjectAsync(string typeName, JsonElement item)
    {
        var entityType = DtoTypesManager.GetDtoType(typeName, "Entity");
        var entity = (object)JsonSerializer.Deserialize(item.GetRawText(), entityType);

        if (_repositories.TryGetValue(typeName, out var repository))
        {
            var repositoryType = repository.GetType();
            var createMethod = repositoryType.GetMethod("CreateAsync", new[] { entityType });
            if (createMethod != null)
            {
                await (Task)createMethod.Invoke(repository, new[] { entity });
            }
            else
            {
                throw new InvalidOperationException($"Repository '{repositoryType.Name}' does not have a CreateAsync method for entity type '{entityType.Name}'.");
            }
        }
        else
        {
            throw new ArgumentException($"Unknown type: {typeName}");
        }
    }
}