//using AlchemyPages.Migrations;
using AlchemyPages.Models;
using AlchemyPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace AlchemyPages.Pages.Ingredients
{
    public class CreateModel : PageModel
    {
        

        private readonly ApplicationDBContext context;
        [BindProperty] public IngredientCreate ingredientCreate { get; set; }
        [BindProperty] public IFormFile ImageFile { get; set; }

        private readonly IWebHostEnvironment _environment;

        public List<SelectListItem> qualityOptions { get; set; }
        public List<SelectListItem> elementOptions { get; set; }

        public CreateModel(ApplicationDBContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            _environment = environment;

        }
        public void OnGet()
        {
            qualityOptions = IngredientQualities.allQualities.Select(quality => new SelectListItem
            { Value = quality, Text = quality }).ToList();

            elementOptions = ElementTypes.allElementTypes.Select(elementType => new SelectListItem 
            { Value = elementType, Text = elementType }).ToList();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Debug.WriteLine("not a valid model");
                OnGet();
                return Page();
            }

            if (ImageFile != null && ImageFile.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                var filePath = Path.Combine(_environment.WebRootPath, "images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                ingredientCreate.imageFileLocation = "/images/" + fileName;

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
            await context.SaveChangesAsync();

            return RedirectToPage("/Ingredients/Index");


        } 
    }
}
