using AlchemyPages.Models;
using AlchemyPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlchemyPages.Pages.Players
{
    public class PlayerViewModel : PageModel
    {
        private readonly ApplicationDBContext context;

        public Player Player { get; set; } = new();

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


            return Page();

        }
    }
}
