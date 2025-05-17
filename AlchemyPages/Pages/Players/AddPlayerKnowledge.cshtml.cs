using AlchemyPages.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AlchemyPages.Models;

namespace AlchemyPages.Pages.Players
{
    public class AddPlayerKnowledgeModel : PageModel
    {
        private readonly ApplicationDBContext context;

        public AddPlayerKnowledgeModel(ApplicationDBContext context)
        {
            this.context = context;  
        }

        [BindProperty] public PlayerKnowledge PlayerKnowledge { get; set; }

        public SelectList Players { get; set; }
        public SelectList Ingredients { get; set; }
        public SelectList QualitiesKnown { get; set; }

        public async Task OnGetAsync()
        {
            Players = new SelectList(await context.Players.ToListAsync(), "PlayerID", "FirstName");
            Ingredients = new SelectList(await context.Ingredients.ToListAsync(), "Id", "Name");
            QualitiesKnown = new SelectList(new[] { 1, 2, 3 });

            if (Players == null || Ingredients == null || QualitiesKnown == null)
            {
                
                Console.WriteLine("either players Ingredients or Quality options are null");

            }
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                if (!ModelState.IsValid)
                {
                    foreach (var entry in ModelState)
                    {
                        foreach (var error in entry.Value.Errors)
                        {
                            Console.WriteLine($"Error in {entry.Key}: {error.ErrorMessage}");
                        }
                    }

                    // repopulate dropdowns
                    await OnGetAsync();
                    return Page();
                }
                await OnGetAsync();
                return Page();
            }

            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model state not valid");
                await OnGetAsync(); return Page();

            }


            context.PlayerKnowledges.Add(PlayerKnowledge);
            Console.WriteLine("content added to db");
            await context.SaveChangesAsync();
            Console.WriteLine("content saved");
            return RedirectToPage("/Admin/index");
        }

    }
}
