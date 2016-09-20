using System.ComponentModel.DataAnnotations;

namespace Table365.Core.Models.ViewModel
{
    public class LoginViewModels
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}