using CookingMasterApi.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CookingMasterApi.Infrastructure.Persistence;

public class CookingMasterDbContextInitialiser
{
    private readonly ILogger<CookingMasterDbContextInitialiser> _logger;
    private readonly CookingMasterDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public CookingMasterDbContextInitialiser(ILogger<CookingMasterDbContextInitialiser> logger, CookingMasterDbContext context, UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("already exists. Choose a different database name"))
            {
                return;
            }
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {

        // Default users
        var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");

        }

    }
}
