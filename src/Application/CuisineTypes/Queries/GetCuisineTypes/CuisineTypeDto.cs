using CookingMasterApi.Application.Common.Mappings;
using CookingMasterApi.Domain.Entities;

namespace CookingMasterApi.Application.CuisineTypes.Queries.GetCuisineTypes;

public class CuisineTypeDto : IMapFrom<CuisineType>
{
    public Guid Uid { get; set; }
    public string CuisineName { get; set; }
}
