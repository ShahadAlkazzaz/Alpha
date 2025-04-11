using Microsoft.AspNetCore.Identity;

namespace WebApp.Models.Entities
{
    // AI-genererad kod: Utökad användarmodell med förnamn och efternamn
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; } = null!;

        [PersonalData]
        public string LastName { get; set; } = null!;
    }
}
