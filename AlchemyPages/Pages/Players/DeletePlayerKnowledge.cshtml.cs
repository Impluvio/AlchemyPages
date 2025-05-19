using AlchemyPages.Models;
using AlchemyPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlchemyPages.Pages.Players
{
    public class DeletePlayerKnowledgeModel : PageModel
    {
        private ApplicationDBContext context;

        public PlayerKnowledge PlayerKnowledge { get; set; }


        public DeletePlayerKnowledgeModel(ApplicationDBContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> OnGetAsync(int PlayerKnowledgeID)
        {
            PlayerKnowledge = await context.PlayerKnowledges.FindAsync(PlayerKnowledgeID);

            if (PlayerKnowledge == null)
            {
                return RedirectToPage("/Players/EditPlayerKnowledge");
            }

            return Page();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            var PlayerknowledgeToDelete =  await context.PlayerKnowledges.FindAsync(PlayerKnowledge.PlayerKnowledgeID);

            if (PlayerknowledgeToDelete != null)
            {
                context.PlayerKnowledges.Remove(PlayerknowledgeToDelete);
                context.SaveChanges();
            }

            return RedirectToPage("Players/EditPlayerKnowledge");


        }
    }
}
