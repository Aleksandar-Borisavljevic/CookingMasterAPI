
using AutoMapper;
using CookingMasterApi.Application.Common.Mappings;
using CookingMasterApi.Domain.Entities;
using MediatR;

namespace CookingMasterApi.Application.IngredientCategories.Commands.Create;
public class CreateIngredientCategoryCommand : IRequest<CreateIngredientCategoryCommandResult>, IMapFrom<IngredientCategory>
{
    public string CategoryName { get; set; }
    public string IconPath { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateIngredientCategoryCommand, IngredientCategory>()
            .ForMember(dest => dest.Uid, opt => Guid.NewGuid());
    }
}
