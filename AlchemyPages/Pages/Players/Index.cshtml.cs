using AlchemyPages.Models;
using AlchemyPages.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlchemyPages.Pages.Players
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext context;
        public List<Player> playerList = new();

        public IndexModel (ApplicationDBContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            playerList = await context.Players.OrderByDescending(i => i.PlayerID).ToListAsync();

            if (playerList == null)
            {
                return RedirectToPage("/Shared/Index");
            }

            return Page();
        }
    }
}
