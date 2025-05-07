using AlchemyPages.Models;
using AlchemyPages.Pages.Players;
using AlchemyPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlchemyPages.Migrations;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace AlchemyPages.Pages.Players
{
    public class CreatePlayerModel : PageModel
    {
        private readonly ApplicationDBContext context;

        [BindProperty] public PlayerCreate playerCreate { get; set; } 


        public CreatePlayerModel(ApplicationDBContext context)
        {
            this.context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Debug.WriteLine("not a valid model");
                return Page();
            }

            var Player = new Player
            {
                FirstName = playerCreate.FirstName,
                LastName = playerCreate.LastName,

            };

            Debug.WriteLine($"player name is:{Player.FirstName}");

            context.Players.Add(Player);
            await context.SaveChangesAsync();
            return RedirectToPage("/Players/Index");


        }


    }
}
