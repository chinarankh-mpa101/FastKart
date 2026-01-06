using Microsoft.AspNetCore.Identity;

namespace FastKart.Models
{
    public class AppUser:IdentityUser
    {
        public string Fullname { get; set; }

    }
}
