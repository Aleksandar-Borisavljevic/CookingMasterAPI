
using AutoMapper;
using CookingMasterApi.Application.Common.Interfaces;
using CookingMasterApi.Domain.Entities;
using MediatR;

namespace CookingMasterApi.Application.IngredientCategories.Commands.Create;
public class CreateIngredientCategoryCommandHandler : IRequestHandler<CreateIngredientCategoryCommand, CreateIngredientCategoryCommandResult>
{
    private readonly ICookingMasterDbContext _context;
    private readonly IMapper _mapper;

    public CreateIngredientCategoryCommandHandler(ICookingMasterDbContext context, IMapper mapper)
    {
        _context = context; 
        _mapper = mapper;
    }
    public async Task<CreateIngredientCategoryCommandResult> Handle(CreateIngredientCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<IngredientCategory>(request);

        var result = (await _context.IngredientCategories.AddAsync(entity)).Entity;

        await _context.SaveChangesAsync(cancellationToken);

        return new CreateIngredientCategoryCommandResult(result.CategoryName, result.IconPath);

    }
}
