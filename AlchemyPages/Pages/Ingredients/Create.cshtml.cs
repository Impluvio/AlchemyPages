using AlchemyPages.Migrations;
using AlchemyPages.Models;
using AlchemyPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Security.Cryptography.Xml;

namespace AlchemyPages.Pages.Ingredients
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext context;
        [BindProperty] public IngredientCreate ingredientCreate { get; set; }

        public CreateModel(ApplicationDBContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {

                Debug.WriteLine("not a valid model");
                return Page();


            }

            var Ingredient = new Ingredient
            {
                Name = ingredientCreate.Name,
                Type = ingredientCreate.Type,
                Element = ingredientCreate.Element,
                Description = ingredientCreate.Description,
                imageFileLocation = ingredientCreate.imageFileLocation,
                qualityOne = ingredientCreate.qualityOne,
                qualityTwo = ingredientCreate.qualityTwo,
                qualityThree = ingredientCreate.qualityThree,

            };

            Debug.WriteLine($"ingredient Name is {Ingredient.Name}");

            context.Ingredients.Add(Ingredient);
            context.SaveChanges();

            return RedirectToPage("/Ingredients/Index");
        } 
    }
}
