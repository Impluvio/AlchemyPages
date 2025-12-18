using AlchemyPages.Models;
using AlchemyPages.Services;
using Azure.Identity;
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

        private readonly IWebHostEnvironment _environment;

        public PlayerViewModel(ApplicationDBContext context,IWebHostEnvironment environment)
        {
            this.context = context;
            _environment = environment;
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

            foreach (var record in KnowledgeList)
            {
                if (!string.IsNullOrEmpty(record.Ingredient.qualityOne))
                {
                    record.Ingredient.qualityOneIconPath = Path.Combine("property-icons", record.Ingredient.qualityOne + ".png");
                }
                if (!string.IsNullOrEmpty(record.Ingredient.qualityTwo))
                {
                    record.Ingredient.qualityTwoIconPath = Path.Combine("property-icons", record.Ingredient.qualityTwo + ".png");
                }
                if (!string.IsNullOrEmpty(record.Ingredient.qualityThree))
                {
                    record.Ingredient.qualityThreeIconPath = Path.Combine("property-icons", record.Ingredient.qualityThree + ".png");
                }
            }

            return Page();

        }
    }
}
