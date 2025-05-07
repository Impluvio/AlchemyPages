using System.ComponentModel.DataAnnotations;
using System.Runtime.ExceptionServices;

namespace AlchemyPages.Models
{
    public class PlayerCreate
    {

        [Required(ErrorMessage = "first name is requied")] public string FirstName { get; set; } = "";
        [Required(ErrorMessage = "you should probably have a last name too")] public string LastName { get; set; } = ""; 

    }
}
