using AutoMapper;
using CookingMasterApi.Application.Common.Mappings;
using CookingMasterApi.Domain.Entities;
using MediatR;

namespace CookingMasterApi.Application.Ingredients.Commands.Create;
public class CreateIngredientCommand : IRequest<CreateIngredientCommandResult>, IMapFrom<Ingredient>
{
    public int IngredientCategoryId { get; set; }
    public IngredientCategory IngredientCategory { get; set; }
    public int IngredientNutrientId { get; set; }
    public IngredientNutrient IngredientNutrient { get; set; }
    public string IngredientName { get; set; }
    public string IconPath { get; set; }
    public short UnitOfMeasure { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateIngredientCommand, Ingredient>()
            .ForMember(dest => dest.Uid, opt => Guid.NewGuid());
    }
}
