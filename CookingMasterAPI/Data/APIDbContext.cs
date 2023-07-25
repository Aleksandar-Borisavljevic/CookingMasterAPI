using CookingMasterAPI.Models.Entity;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

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

        //Defining connection string which leads to server
        private const string LocalConnectionString = "Server =(local)\\sqlexpress;Database=CookingMaster_DB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True";
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(LocalConnectionString);
        }
    }   */

    }
}
