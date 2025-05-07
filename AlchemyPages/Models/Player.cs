using System.ComponentModel.DataAnnotations;

namespace AlchemyPages.Models
{
    public class Player
    {
        public int PlayerID { get; set; }

        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }

        public ICollection<IngredientEncounter> IngredientEncounters { get; set; }
    }
}
