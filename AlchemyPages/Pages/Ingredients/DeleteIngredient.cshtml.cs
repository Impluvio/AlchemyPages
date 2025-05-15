using AlchemyPages.Models;
using AlchemyPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AlchemyPages.Pages.Ingredients
{
    public class DeleteIngredientModel : PageModel
    {
        private readonly ApplicationDBContext context;

        [BindProperty] public Ingredient Ingredient { get; set; }

        public DeleteIngredientModel(ApplicationDBContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> OnGetAsync(int Id)
        {
            
            {
                Ingredient = await context.Ingredients.FindAsync(Id);

                if (Ingredient == null)
                {
                    return RedirectToPage("/Ingredient/Index");
                }

                return Page();

            }

        }

        public async Task <IActionResult> OnPostAsync()
        {
            var ingredientToDelete = await context.Ingredients.FindAsync(Ingredient.Id);

            if (ingredientToDelete != null)
            {
                context.Ingredients.Remove(ingredientToDelete);
                context.SaveChanges();
            }

            return RedirectToPage("/Ingredients/Index");
        }
    }

}
