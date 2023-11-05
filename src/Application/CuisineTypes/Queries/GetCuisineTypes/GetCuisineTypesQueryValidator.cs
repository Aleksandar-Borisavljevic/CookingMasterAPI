using FluentValidation;

namespace CookingMasterApi.Application.CuisineTypes.Queries.GetCuisineTypes;

public class GetCuisineTypesQueryValidator : AbstractValidator<GetCuisineTypesQuery>
{
    public GetCuisineTypesQueryValidator()
    {
    }
}
