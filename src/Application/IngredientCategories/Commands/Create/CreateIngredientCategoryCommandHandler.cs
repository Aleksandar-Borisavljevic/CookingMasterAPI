
using CookingMasterApi.Application.Common.Interfaces;
using MediatR;

namespace CookingMasterApi.Application.IngredientCategories.Commands.Create;
internal class CreateIngredientCategoryCommandHandler : IRequestHandler<CreateIngredientCategoryCommand, CreateIngredientCategoryCommandResult>
{
    ICookingMasterDbContext _context;
    private readonly ICurrentUserService _currentUserService;

    public CreateIngredientCategoryCommandHandler(ICookingMasterDbContext context, ICurrentUserService currentUserService)
    {
        _context = context; 
        _currentUserService = currentUserService;
    }
    public async Task<CreateIngredientCategoryCommandResult> Handle(CreateIngredientCategoryCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;

        return new CreateIngredientCategoryCommandResult("Lemon", "lemon");

    }
}
