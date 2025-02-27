namespace SaplingStore.Models;

using DTOs.SaplingCategory;
using DTOs.SaplingDTO;
using DTOs.SaplingHeightDto;

    public static class DtoTypesManager
    {
        // Sapling için DTO türlerini saklayan bir sözlük
        private static readonly Dictionary<string, Type> SaplingDtoTypes = new Dictionary<string, Type>
        {
            { "CreateDto", typeof(SaplingCreateDto) },
            { "UpdateDto", typeof(SaplingUpdateDto) },
            { "ReadDto", typeof(SaplingReadDto) }
        };

        // Tree için DTO türlerini saklayan bir sözlük
        private static readonly Dictionary<string, Type> SaplingCategoryDtoTypes = new Dictionary<string, Type>
        {
            { "CreateDto", typeof(SaplingCategoryCreateDto) },
            { "UpdateDto", typeof(SaplingCategoryUpdateDto) },
            { "ReadDto", typeof(SaplingCategoryReadDto) }
        };

        // Plant için DTO türlerini saklayan bir sözlük
        private static readonly Dictionary<string, Type> SaplingHeightCategoryDtoTypes = new Dictionary<string, Type>
        {
            { "CreateDto", typeof(SaplingHeightCreateDto) },
            { "UpdateDto", typeof(SaplingHeightUpdateDto) },
            { "ReadDto", typeof(SaplingHeightReadDto) }
        };

        // DTO türlerini almak için genel bir metot
        public static Dictionary<string, Type> GetDtoTypes(string entityName)
        {
            switch (entityName)
            {
                case "Sapling":
                    return SaplingDtoTypes;
                case "SaplingCategory":
                    return SaplingCategoryDtoTypes;
                case "SaplingHeight":
                    return SaplingHeightCategoryDtoTypes;
                default:
                    throw new ArgumentException($"Entity '{entityName}' için DTO türleri bulunamadı.");
            }
        }
        public static Type GetCreateDtoType(string entityName) {
            switch (entityName)
            {
                case "Sapling":
                    return SaplingDtoTypes["CreateDto"];
                case "SaplingCategory":
                    return SaplingCategoryDtoTypes["CreateDto"];
                case "SaplingHeight":
                    return SaplingHeightCategoryDtoTypes["CreateDto"];
                default:
                    throw new ArgumentException($"Entity '{entityName}' için DTO türleri bulunamadı.");
            }
        }
    }

