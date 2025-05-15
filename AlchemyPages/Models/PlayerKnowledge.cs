using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AlchemyPages.Models
{
    public class PlayerKnowledge
    {

        [Key] public int PlayerIngredientEncounterID { get; set; }

        [ForeignKey("Player")] public int PlayerID { get; set; }

        public Player Player { get; set; } 

        [ForeignKey("Ingredient")] public int Id { get; set; }

        public Ingredient Ingredient { get; set; }

        [Range(1, 3, ErrorMessage = "QualityKnown must be between 1 and 3.")]  public int qualitiesKnown { get; set; }
    }
}
