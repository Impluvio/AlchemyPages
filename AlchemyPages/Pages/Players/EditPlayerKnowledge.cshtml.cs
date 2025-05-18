using AlchemyPages.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlchemyPages.Services;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace AlchemyPages.Pages.Players
{
    public class EditPlayerKnowledgeModel : PageModel
    {
        private readonly ApplicationDBContext context;
        [BindProperty(SupportsGet= true)] public int? SelectedPlayerID { get; set; }
        public SelectList Players { get; set; }
        public List<PlayerKnowledge> PlayerKnowledgeList { get; set; }

        public EditPlayerKnowledgeModel(ApplicationDBContext context)
        {
            this.context = context;

        }


        public async Task<IActionResult> OnGetAsync()
        {
            Players = new SelectList(await context.Players.ToListAsync(), "PlayerID", "FirstName");

            if (SelectedPlayerID != null)
            {
                PlayerKnowledgeList = await context.PlayerKnowledges.Where(pk => pk.PlayerID == SelectedPlayerID).Include(pk => pk.Ingredient).OrderByDescending(pk => pk.IngredientId).ToListAsync();
            }
            else
            {
                PlayerKnowledgeList = new List<PlayerKnowledge>();
            }

            return Page();

        }

        public async Task OnPostAsync()
        {

        }


    }
}
