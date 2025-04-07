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

        //protected ApplicationDBContext()
        //{
        //}
    }
}
