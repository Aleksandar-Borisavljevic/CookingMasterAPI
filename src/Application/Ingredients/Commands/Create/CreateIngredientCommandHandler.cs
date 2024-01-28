using AutoMapper;
using CookingMasterApi.Application.Common.Interfaces;
using MediatR;

namespace CookingMasterApi.Application.Ingredients.Commands.Create;
public class CreateIngredientCommandHandler : IRequestHandler<CreateIngredientCommand, CreateIngredientCommandResult>
{
    private readonly ICookingMasterDbContext _context;
    private readonly IMapper _mapper;

    public CreateIngredientCommandHandler(ICookingMasterDbContext context, IMapper mapper)
    {
        _context = context; 
        _mapper = mapper;
    }
    public async Task<CreateIngredientCommandResult> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
    {
        //var entity = _mapper.Map<Ingredient>(request);

        //var result = (await _context.Ingredients.AddAsync(entity)).Entity;

        //await _context.SaveChangesAsync(cancellationToken);

        return new CreateIngredientCommandResult("", "");

    }
}
