using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;


namespace AlchemyPages.Models
{
    [Index(nameof(PlayerID), nameof(IngredientId), IsUnique = true)]
    public class PlayerKnowledge
    {

        [Key] 
        public int PlayerKnowledgeID { get; set; }



        [ForeignKey("Player")]
        public int PlayerID { get; set; }
        [ValidateNever]
        public Player Player { get; set; }


        [ForeignKey("Ingredient")]
        public int IngredientId { get; set; }
        [ValidateNever]
        public Ingredient Ingredient { get; set; }

        [Range(1, 3, ErrorMessage = "QualityKnown must be between 1 and 3.")] 
        public int QualitiesKnown { get; set; }


        
    }
}
