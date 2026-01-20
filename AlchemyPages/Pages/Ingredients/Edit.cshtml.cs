using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlchemyPages.Services;
using AlchemyPages.Models;
using System.Xml.Linq;
using Microsoft.Data.SqlClient.DataClassification;
using System.Diagnostics;

namespace AlchemyPages.Pages.Ingredients
{
    public class EditModel : PageModel
    {
        // Problem in this script, process is Form, creates instance of PlayerCreate / IngredientCreate model which feeds to class player/Ingredient here instance ingredient takes in data and is then updated before pushed to sql. either
        // the script is unclear - so player instance should be called something else then updated. 


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

        public async Task <IActionResult> OnGetAsync(int id)
        {
            var ingredientToBeEdited = await context.Ingredients.FindAsync(id);

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


        public async Task<IActionResult> OnPostAsync(int id)
        {
            var ingredientToBeEdited = await context.Ingredients.FindAsync(id);

            if (ingredientToBeEdited == null)
            {
                Debug.WriteLine("not a valid model");
                return Page();
            }
            ingredientToBeEdited.Name = ingredientCreate.Name;
            ingredientToBeEdited.Type = ingredientCreate.Type;
            ingredientToBeEdited.Element = ingredientCreate.Element;
            ingredientToBeEdited.Description = ingredientCreate.Description;
            ingredientToBeEdited.imageFileLocation = ingredientCreate.imageFileLocation;
            ingredientToBeEdited.qualityOne = ingredientCreate.qualityOne;
            ingredientToBeEdited.qualityTwo = ingredientCreate.qualityTwo;
            ingredientToBeEdited.qualityThree = ingredientCreate.qualityThree;


            await context.SaveChangesAsync();
            return RedirectToPage("/Ingredients/Index");

            //return Page();
        }

    
    }
}
