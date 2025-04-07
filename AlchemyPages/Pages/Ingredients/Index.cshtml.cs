using AlchemyPages.Models;
using AlchemyPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlchemyPages.Pages.Ingredients
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext context;

        public List<Ingredient> ingredientList = new();
        public IndexModel(ApplicationDBContext context)
        {
            this.context = context;
        }

        public void OnGet()
        {

            ingredientList = context.Ingredients.OrderByDescending(i => i.Id).ToList();

        }
    }
}
