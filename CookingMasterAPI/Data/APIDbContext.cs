using Microsoft.EntityFrameworkCore;
using CookingMasterAPI.Models.Entity;



namespace CookingMasterAPI.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> option)
            : base(option)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<IngredientCategory> IngredientCategories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<UserIngredient> UserIngredients { get; set; }
        public DbSet<IngredientNutrient> IngredientNutrients { get; set; }

        //Defining connection string which leads to server
        private const string LocalConnectionString = "Server =(local)\\sqlexpress;Database=Server=localhost\\SQLEXPRESS;Database=CookingMaster_DB;Trusted_Connection=True;;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True";
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(LocalConnectionString);
        }
    }   */

    }
}
