using System.ComponentModel.DataAnnotations.Schema;

namespace AlchemyPages.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
        public string Element { get; set; } = "";
        public string Description { get; set; } = "";

        public string imageFileLocation { get; set; } = "";

        public string qualityOne { get; set; } = "";
        public string qualityTwo { get; set; } = "";
        public string qualityThree { get; set; } = "";

        //unmapped references so we can find the correct images for the icons without storing in DB. 
        [NotMapped] public string qualityOneIconPath { get; set; }
        [NotMapped] public string qualityTwoIconPath { get; set; }
        [NotMapped] public string qualityThreeIconPath { get; set; }

        public ICollection<IngredientEncounter> IngredientEncounters { get; set; }

    }
}
