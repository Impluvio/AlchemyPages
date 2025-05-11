using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlchemyPages.Services;
using AlchemyPages.Models;
using System.Xml.Linq;
using System.Diagnostics;

namespace AlchemyPages.Pages.Players
{
    public class EditPlayerModel : PageModel
    {
        [BindProperty] public PlayerCreate playerCreate { get; set; } = new PlayerCreate();
        public Player Player { get; set; } = new();

        private readonly ApplicationDBContext context;

     

        public EditPlayerModel(ApplicationDBContext context)
        {
            this.context = context; 

        }



        public IActionResult OnGet(int PlayerID)
        {
            var displayPlayerToBeEdited = context.Players.Find(PlayerID);

            if (displayPlayerToBeEdited == null)
            {
                return RedirectToPage("/Players/Index");
            }

            Player = displayPlayerToBeEdited;

            playerCreate.FirstName = displayPlayerToBeEdited.FirstName;
            playerCreate.LastName = displayPlayerToBeEdited.LastName;


            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int PlayerID)
        {
            var playerToBeEdited = context.Players.Find(PlayerID);

            if (playerToBeEdited == null)
            {
                Debug.WriteLine("not a valid model");
                return Page();
            }

            playerToBeEdited.FirstName = playerCreate.FirstName;
            playerToBeEdited.LastName = playerCreate.LastName;

            await context.SaveChangesAsync();
            return RedirectToPage("/Players/Index");
        }

    }
}
