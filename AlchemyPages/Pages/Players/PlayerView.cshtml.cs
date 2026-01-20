using AlchemyPages.Models;
using AlchemyPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlchemyPages.Pages.Players
{
    public class PlayerViewModel : PageModel
    {
        private readonly ApplicationDBContext context;
        public List<Player> playerList = new();
        public Player Player { get; set; }

        public PlayerViewModel(ApplicationDBContext context)
        {
            this.context = context;
       
        }

        public async void OnGetAsync(int id, int PlayerID)
        {
            var playerToDisplay = await context.Players.FindAsync(PlayerID);
           

        }
    }
}
