using System.ComponentModel.DataAnnotations;

namespace AlchemyPages.Models
{
    public class IngredientCreate
    {
        [Required(ErrorMessage = "Name is required")] public string Name { get; set; } = "";
        [Required] public string Type { get; set; } = "";
        [Required] public string Element { get; set; } = "";
        [Required] public string Description { get; set; } = "";

        public string imageFileLocation { get; set; } = "";

        [Required] public string qualityOne { get; set; } = "";
        [Required] public string qualityTwo { get; set; } = "";
        [Required] public string qualityThree { get; set; } = "";
    }
}
