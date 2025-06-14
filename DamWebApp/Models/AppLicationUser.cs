using Microsoft.AspNetCore.Identity;

namespace DamWebApp.Models
{
    public class AppLicationUser:IdentityUser
    {
        public string? Address { get; set; }
    }
}
