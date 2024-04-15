using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using ProjektiPersonal.Models;

namespace ProjektiPersonal.Repository
{
    public class Data : IData
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public Data( UserManager<ApplicationUser> manager)
        { 
            _userManager = manager;
        }
        public async Task<ApplicationUser> GetUser(ClaimsPrincipal claims)
        {
            return await _userManager.GetUserAsync(claims);
        }
    }
}