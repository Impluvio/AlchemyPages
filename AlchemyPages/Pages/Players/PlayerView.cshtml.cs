using AlchemyPages.Models;
using AlchemyPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AlchemyPages.Pages.Players
{
    public class PlayerViewModel : PageModel
    {
        private readonly ApplicationDBContext context;

        public Player Player { get; set; } = new();
        public PlayerKnowledge Knowledge { get; set; }
        public Ingredient Ingredient { get; set; }

        public List<PlayerKnowledge> KnowledgeList { get; set; }


        public PlayerViewModel(ApplicationDBContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> OnGetAsync(int PlayerID)
        {

            var playerToDisplay = await context.Players.FindAsync(PlayerID);

            if (playerToDisplay == null)
            {
                return RedirectToPage("/Players/Index");
            }

            Player = playerToDisplay;

            KnowledgeList = await context.PlayerKnowledges.Where(record => record.PlayerID == PlayerID).Include(record => record.Ingredient).ToListAsync();

            return Page();

        }
    }
}
