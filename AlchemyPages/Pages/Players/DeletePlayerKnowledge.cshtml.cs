using AlchemyPages.Models;
using AlchemyPages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Threading.Tasks.Dataflow;

namespace AlchemyPages.Pages.Players
{
    public class DeletePlayerKnowledgeModel : PageModel
    {
        private readonly ApplicationDBContext context;

       [BindProperty] public PlayerKnowledge PlayerKnowledge { get; set; }

        public DeletePlayerKnowledgeModel(ApplicationDBContext context)
        {
            this.context = context;
        }


      

        public async Task<IActionResult> OnGetAsync(int Id)
        {
           
            PlayerKnowledge = await context.PlayerKnowledges.Include(playerK => playerK.Ingredient).FirstOrDefaultAsync(playerK => playerK.PlayerKnowledgeID == Id);
           
            if (PlayerKnowledge == null)
            {
                Debug.WriteLine("player knowledge NULL");
                return RedirectToPage("/Players/EditPlayerKnowledge");
            }

            return Page();

        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Debug.WriteLine("on POST Async hit");


            //if (PlayerKnowledge == null || PlayerKnowledge.PlayerKnowledgeID == 0)
            //{
            //    return RedirectToPage("/Players/EditPlayerKnowledge");
            //}

            var PlayerknowledgeToDelete =  await context.PlayerKnowledges.FindAsync(id);

            if (PlayerknowledgeToDelete != null)
            {
                context.PlayerKnowledges.Remove(PlayerknowledgeToDelete);
                context.SaveChanges();
            }

            return RedirectToPage("/Players/EditPlayerKnowledge");


        }
    }
}
