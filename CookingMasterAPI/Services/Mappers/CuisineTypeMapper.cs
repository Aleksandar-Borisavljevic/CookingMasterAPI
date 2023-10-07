using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Response;

namespace CookingMasterAPI.Services.Mappers
{
    public static class CuisineTypeMapper
    {
        public static CuisineTypeResponse MapCuisineTypeToResponse(CuisineType cuisineType)
        {
            return new CuisineTypeResponse
                (
                cuisineType.CuisineId,
                cuisineType.CuisineName,
                cuisineType.Uid
                );
        }

        public static IEnumerable<CuisineTypeResponse> MapCuisineTypesToResponse(IEnumerable<CuisineType> cuisineTypes)
        {
            return cuisineTypes.Select(MapCuisineTypeToResponse);
        }
    }
}
