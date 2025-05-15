using AlchemyPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlchemyPages.Models;

namespace AlchemyPages.Pages.Players
{
    public class DeletePlayerModel : PageModel
    {
        private readonly ApplicationDBContext context;

        [BindProperty] public Player Player { get; set; }

        public DeletePlayerModel(ApplicationDBContext context)
        {
            this.context = context;
        }


        public async Task<IActionResult> OnGetAsync(int PlayerID)
        {
            Player = await context.Players.FindAsync(PlayerID);

            if (Player == null)
            {
                return RedirectToPage("/Player/Index");
            }
            return Page();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            var playerToDelete = await context.Players.FindAsync(Player.PlayerID);

            if (playerToDelete != null)
            {
                context.Players.Remove(playerToDelete);
                context.SaveChanges();
            }

            return RedirectToPage("/Players/Index");
        }
    }


}
