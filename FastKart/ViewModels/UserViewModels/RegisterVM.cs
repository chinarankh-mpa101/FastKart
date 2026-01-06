using System.ComponentModel.DataAnnotations;

namespace FastKart.ViewModels.UserViewModels
{
    public class RegisterVM
    {
        [Required, MaxLength(256)]
        public string Fullname { get; set; } = string.Empty;


        [Required, MaxLength(256)]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; }

        [Required, MinLength(4), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
