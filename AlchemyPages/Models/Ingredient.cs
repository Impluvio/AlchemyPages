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

        public ICollection<IngredientEncounter> IngredientEncounters { get; set; }

    }
}
