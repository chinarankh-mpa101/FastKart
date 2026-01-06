using System.ComponentModel.DataAnnotations;

namespace FastKart.ViewModels.UserViewModels
{
    public class LoginVM
    {
        [Required,MaxLength(256), EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(4), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
