using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlchemyPages.Services;
using AlchemyPages.Models;
using System.Xml.Linq;

namespace AlchemyPages.Pages.Ingredients
{
    public class EditModel : PageModel
    {

        [BindProperty] public IngredientCreate ingredientCreate { get; set; } = new IngredientCreate();

        public Ingredient Ingredient { get; set; } = new();

        private readonly ApplicationDBContext context;

        public EditModel(ApplicationDBContext context)
        {
            this.context = context;

        }

        public IActionResult OnGet(int id)
        {
            var ingredientToBeEdited = context.Ingredients.Find(id);

            if (ingredientToBeEdited == null)
            {
                return RedirectToPage("/IngredientIndex");
            }

            Ingredient = ingredientToBeEdited;

            ingredientCreate.Name = ingredientToBeEdited.Name;
            ingredientCreate.Type = ingredientToBeEdited.Type;
            ingredientCreate.Element = ingredientToBeEdited.Element;
            ingredientCreate.Description = ingredientToBeEdited.Description;
            ingredientCreate.imageFileLocation = ingredientToBeEdited.imageFileLocation;
            ingredientCreate.qualityOne = ingredientToBeEdited.qualityOne;
            ingredientCreate.qualityTwo = ingredientToBeEdited.qualityTwo;
            ingredientCreate.qualityThree = ingredientToBeEdited.qualityThree;


            return Page();
        }
    }
}
