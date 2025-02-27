namespace SaplingStore.Models;

using DTOs.SaplingCategory;
using DTOs.SaplingDTO;
using DTOs.SaplingHeightDto;

    public static class DtoTypesManager
    {
       private static readonly Dictionary<string, Dictionary<string, Type>> DtoTypes = new Dictionary<string, Dictionary<string, Type>>
    {
        {
            "Sapling", new Dictionary<string, Type>
            {
                {"Entity", typeof(Sapling)},
                {"CreateDto", typeof(SaplingCreateDto)},
                {"UpdateDto", typeof(SaplingUpdateDto)},
                {"ReadDto", typeof(SaplingReadDto)}
            }
        },
        {
            "SaplingCategory", new Dictionary<string, Type>
            {
                {"Entity", typeof(SaplingCategory)},
                {"CreateDto", typeof(SaplingCategoryCreateDto)},
                {"UpdateDto", typeof(SaplingCategoryUpdateDto)},
                {"ReadDto", typeof(SaplingCategoryReadDto)}
            }
        },
        {
            "SaplingHeight", new Dictionary<string, Type>
            {
                {"Entity", typeof(SaplingHeight)},
                {"CreateDto", typeof(SaplingHeightCreateDto)},
                {"UpdateDto", typeof(SaplingHeightUpdateDto)},
                {"ReadDto", typeof(SaplingHeightReadDto)}
            }
        }
    };

    // DTO türlerini almak için genel bir metot
    public static Dictionary<string, Type> GetDtoTypes(string entityName)
    {
        if (DtoTypes.TryGetValue(entityName, out var dtoTypes))
        {
            return dtoTypes;
        }
        throw new ArgumentException($"Entity '{entityName}' için DTO türleri bulunamadı.");
    }

    // Belirli bir DTO türünü almak için genel bir metot
    public static Type GetDtoType(string entityName, string dtoTypeName)
    {
        if (DtoTypes.TryGetValue(entityName, out var dtoTypes) && dtoTypes.TryGetValue(dtoTypeName, out var dtoType))
        {
            return dtoType;
        }
        throw new ArgumentException($"Entity '{entityName}' için '{dtoTypeName}' DTO türü bulunamadı.");
    }
    public static List<string> GetEntities() {
        return DtoTypes.Keys.ToList();
    }

    // CreateDto türünü almak için özel bir metot
    public static Type GetCreateDtoType(string entityName)
    {
        return GetDtoType(entityName, "CreateDto");
    }
    }

