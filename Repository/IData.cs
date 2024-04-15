using System.Security.Claims;
using ProjektiPersonal.Models;

namespace ProjektiPersonal.Repository{
    public interface IData
    {
        Task<ApplicationUser> GetUser(ClaimsPrincipal claims);
    }
}