using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WebApp.Models.Entities;

namespace WebApp.Services
{
    // AI-genererad kod: Inkapslad inloggningslogik i AccountService för att separera ansvar från controllern och lägga till claims.
    public class AccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<bool> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                return false;

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (result.Succeeded)
            {
                // Logga ut eventuell gammal session
                await _signInManager.SignOutAsync();

                // Lägg till fullständigt namn som claim
                await _signInManager.SignInWithClaimsAsync(user, false, new List<Claim>
        {
            new Claim("FullName", $"{user.FirstName} {user.LastName}")
        });

                return true;
            }

            return false;
        }



    }
}
