using System.Text.Json;
using System.Text.Json.Serialization;
using SaplingStore.Data;
using SaplingStore.Helpers;
using SaplingStore.Interfaces;

public static class SeedData  {
   public static async Task ExportCurrentData(AppDbContext context,  object[] repositories)
{
    var exportData = new Dictionary<string, object>();

    foreach (var repository in repositories)
    {
        // Repository'nin tipini al
        var repoType = repository.GetType();

        // Generic interface'in tipini bul (IClassRepository<T>)
        var genericInterface = repoType.GetInterfaces()
            .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IClassRepository<>));

        if (genericInterface != null)
        {
            // Entity tipini al (T)
            var entityType = genericInterface.GetGenericArguments()[0];
            
            // GetAllAsync metodunun parametre tipini al
            var getAllMethod = repoType.GetMethod("GetAllAsync", Type.EmptyTypes);  // Parametresiz metod için

            if (getAllMethod == null)
            {
                // Parametreli GetAllAsync metodunu al (örneğin, QueryObject türünde bir parametre)
                getAllMethod = repoType.GetMethod("GetAllAsync", new Type[] { typeof(QueryObject) });
            }

            if (getAllMethod != null)
            {
                // Parametre kontrolü yapın
                var parameters = getAllMethod.GetParameters();

                if (parameters.Length == 0)
                {
                    // Parametre almazsa, metodu çağır
                    var task = (Task)getAllMethod.Invoke(repository, null);
                    await task;

                    // Task'in Result property'sini al
                    var resultProperty = task.GetType().GetProperty("Result");
                    var data = resultProperty.GetValue(task);

                    // Veriyi dictionary'e ekle
                    exportData.Add(entityType.Name, data);
                }
                else
                {
                    // Parametre alıyorsa, doğru parametreyi ilet
                    var queryObject = new QueryObject(); // veya uygun parametre
                    var task = (Task)getAllMethod.Invoke(repository, new object[] { queryObject });
                    await task;

                    var resultProperty = task.GetType().GetProperty("Result");
                    var data = resultProperty.GetValue(task);

                    // Veriyi dictionary'e ekle
                    exportData.Add(entityType.Name, data);
                }
            }
        }
    }

    // JSON'a çevir ve kaydet
    var json = JsonSerializer.Serialize(exportData, new JsonSerializerOptions
    {
        WriteIndented = true,
        ReferenceHandler = ReferenceHandler.Preserve
    });

    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "SeedData.json");
    await File.WriteAllTextAsync(filePath, json);
}

}