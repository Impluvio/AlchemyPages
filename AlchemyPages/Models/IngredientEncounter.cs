namespace AlchemyPages.Models
{
    public class IngredientEncounter
    {
        public int IngredientEncounterID { get; set; }
        public int PlayerID { get; set; }
        public Player Player { get; set; }
        public int ingredientID { get; set; }
        public Ingredient Ingredient { get; set; }
        public DateTime EncounterDate { get; set; } 

       
       
    }
}
