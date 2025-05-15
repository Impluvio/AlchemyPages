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
        public SelectList qualitiesKnown { get; set; }

        public async Task OnGetAsync()
        {
            Players = new SelectList(await context.Players.ToListAsync(), "PlayerID", "FirstName");
            Ingredients = new SelectList(await context.Ingredients.ToListAsync(), "Id", "Name");
            qualitiesKnown = new SelectList(new[] { 1, 2, 3 });

            if (Players == null || Ingredients == null || qualitiesKnown == null)
            {
                
                Console.WriteLine("either players Ingredients or Quality options are null");

            }
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync(); return Page();
            }
            context.PlayerKnowledgeBase.Add(PlayerKnowledge);
            await context.SaveChangesAsync();
            return RedirectToPage("/Admin/index");
        }

    }
}
