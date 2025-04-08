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

        [BindProperty] public IFormFile ImageFile {get; set;}

        public Ingredient Ingredient { get; set; } = new();

        private readonly ApplicationDBContext context;
        private readonly IWebHostEnvironment _environment;

        public EditModel(ApplicationDBContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            _environment = environment; 
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
