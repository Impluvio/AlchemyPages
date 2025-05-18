using AlchemyPages.Models;
using AlchemyPages.Services;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> OnGetAsync()
        {
            ingredientList = await context.Ingredients.OrderByDescending(i => i.Id).ToListAsync();

            if (ingredientList == null)
            {
                return RedirectToPage("/Ingredients/Index/");
            }

            return Page();
        }
    }
}
