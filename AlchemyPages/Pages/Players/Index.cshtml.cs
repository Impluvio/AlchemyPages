using AlchemyPages.Models;
using AlchemyPages.Services;
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

        //db context
        // pull list from db.players
        // on get ref. 

        public void OnGet()
        {
            playerList = context.Players.OrderByDescending(i => i.PlayerID).ToList();
        }
    }
}
