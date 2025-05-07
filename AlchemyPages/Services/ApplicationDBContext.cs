using Microsoft.EntityFrameworkCore;
using AlchemyPages.Models;

namespace AlchemyPages.Services
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Player> Players { get; set; }

        public DbSet<IngredientEncounter> IngredientEncounters {get; set;} 

        //protected ApplicationDBContext()
        //{
        //}
    }
}
